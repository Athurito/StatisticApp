using System.ComponentModel;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Statistic.Application.DTOs;
using Statistic.Application.Pdf;
using Statistic.Application.Services;
using Statistic.Wpf.Messages;

namespace Statistic.Wpf.ViewModel;

public partial class StatisticViewModel : ObservableObject
{
    [ObservableProperty] private List<AddressDto>? _addresses = [];
    [NotifyCanExecuteChangedFor(nameof(CreatePdfCommand)), ObservableProperty] 
    private List<VisitorDto>? _visitors = [];

    [ObservableProperty] private ICollectionView? _addressView;
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

    public StatisticViewModel(IVisitorService visitorService, IAddressService addressService, IPdfService pdfService)
    {
        _visitorService = visitorService;
        _addressService = addressService;
        _pdfService = pdfService;
    }

    [RelayCommand]
    private async Task WindowLoaded()
    {
        await FillAddresses();
        await FillVisitors();
        ConfigureAddressView();
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task Save()
    {
        var visitorDto = CreateVisitorDto();
        await _visitorService.CreateVisitor(visitorDto);
        await FillVisitors();
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
    
    private async Task FillAddresses()
    {
        try
        {
            Addresses = [..await _addressService.GetAll()];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task FillVisitors()
    {
        try
        {
            Visitors = [..await _visitorService.GetAll()];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
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