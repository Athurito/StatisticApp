using System.ComponentModel;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Statistic.Application.DTOs;
using Statistic.Application.Pdf;
using Statistic.Application.Services;
using Statistic.Infrastructure.Service;
using Statistic.Wpf.Messages;
using Statistic.Wpf.Sorter;

namespace Statistic.Wpf.ViewModel;

public partial class StatisticViewModel : ObservableObject
{
    [ObservableProperty] private List<AddressDto>? _addresses = [];
    [NotifyCanExecuteChangedFor(nameof(CreatePdfCommand)), ObservableProperty] 
    private List<VisitorDto>? _visitors = [];

    [ObservableProperty] private ICollectionView? _addressView;
    [ObservableProperty] private ListCollectionView? _visitorView;
    [ObservableProperty] private string _zipCode = string.Empty;
    
    [NotifyCanExecuteChangedFor(nameof(SaveCommand)), ObservableProperty] 
    private bool _commonSelected;
    [NotifyCanExecuteChangedFor(nameof(SaveCommand)), ObservableProperty] 
    private bool _bfiSelected;
    [NotifyCanExecuteChangedFor(nameof(SaveCommand)), ObservableProperty] 
    private bool _sySelected;
    [NotifyCanExecuteChangedFor(nameof(SaveCommand)), ObservableProperty] 
    private bool _fwiSelected;
    [NotifyCanExecuteChangedFor(nameof(SaveCommand)), ObservableProperty] 
    private bool _witSelected;
    [NotifyCanExecuteChangedFor(nameof(SaveCommand)), ObservableProperty] 
    private AddressDto? _selectedAddress;
    
    private readonly IVisitorService _visitorService;
    private readonly IAddressService _addressService;
    private readonly IPdfService _pdfService;
    private readonly IDatabaseService _databaseService;

    public StatisticViewModel(IVisitorService visitorService, IAddressService addressService, IPdfService pdfService, 
        IDatabaseService databaseService)
    {
        _visitorService = visitorService;
        _addressService = addressService;
        _pdfService = pdfService;
        _databaseService = databaseService;
    }

    [RelayCommand]
    private async Task WindowLoaded()
    {
        try
        {
             await EnsureDataBase();
             await FillAddresses();
             await FillVisitors();
             ConfigureAddressView();
             ConfigureVisitorView();
        }
        catch (Exception e)
        {
            var message = new ApplicationStartErrorMessage($"Fehler beim Laden der App: {e.Message}");
            WeakReferenceMessenger.Default.Send(message);
        } 
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task Save()
    {
        var visitorDto = CreateVisitorDto();
        await _visitorService.CreateVisitor(visitorDto);
        await FillVisitors();
        ConfigureVisitorView();
        ResetValues();
    }

    [RelayCommand]
    private void ZipCodeTextChanged()
    {
        AddressView!.Refresh();
    }
    
    [RelayCommand(CanExecute = nameof(CanCreatePdf) )]
    private async Task CreatePdf()
    {
        try
        {
            var dialogHelper = await WeakReferenceMessenger.Default.Send<DirectoryMessage>();
            if (!dialogHelper.DialogResult)
            {
                return;
            }
            _pdfService.CreatePdf(Visitors!, dialogHelper.SelectedPath!);

            WeakReferenceMessenger.Default.Send(new PdfSuccessMessage("Pdf wurde erstellt!"));
        }
        catch (Exception ex)
        {
            var message = new PdfErrorMessage($"Fehler beim erstellen der Pdf: {ex.Message}");
            WeakReferenceMessenger.Default.Send(message);
        }
    }

    private async Task EnsureDataBase()
    {
        _databaseService.EnsureDataBase();
        await _databaseService.SeedDataBaseAsync();
    }
    
    private async Task FillAddresses()
    {
        Addresses = [..await _addressService.GetAll()];
    }

    private async Task FillVisitors()
    {
        Visitors = [..await _visitorService.GetAll()];
    }
    
    private VisitorDto CreateVisitorDto()
    {
        var visitorDto = new VisitorDto
        {
            CreateDate = DateTime.Now,
            AddressDto = SelectedAddress!,
            VisitorInterests = new[]
            {
                CommonSelected,
                BfiSelected,
                SySelected,
                FwiSelected,
                WitSelected
            }
        };
        return visitorDto;
    }

    private void ConfigureAddressView()
    {
        AddressView = CollectionViewSource.GetDefaultView(Addresses!);
        AddressView.Filter = FilterZipCode;
    }

    private void ConfigureVisitorView()
    {
        VisitorView = (ListCollectionView)CollectionViewSource.GetDefaultView(Visitors!);
        VisitorView.CustomSort = new VisitorSorter();
    }
    
    private bool FilterZipCode(object obj)
    {
        var address = obj as AddressDto;
        return address!.ZipCode!.Contains(ZipCode);
    }

    private void ResetValues()
    {
        CommonSelected = false;
        BfiSelected = false;
        SySelected = false;
        FwiSelected = false;
        WitSelected = false;
        ZipCode = string.Empty;
        SelectedAddress = null;
    }
    private bool CanSave()
    {
        return (CommonSelected || BfiSelected || SySelected || FwiSelected || WitSelected) 
               && SelectedAddress is not null ;
    }

    private bool CanCreatePdf()
    {
        return Visitors!.Count > 0;
    }
}