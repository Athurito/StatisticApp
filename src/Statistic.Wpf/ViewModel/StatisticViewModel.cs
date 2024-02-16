using System.ComponentModel;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Statistic.Application.DTOs;
using Statistic.Application.Services;

namespace Statistic.Wpf.ViewModel;

public partial class StatisticViewModel : ObservableObject
{
    [ObservableProperty] private List<AddressDto>? _addresses = [];
    [ObservableProperty] private List<VisitorDto>? _visitors = [];

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
    public StatisticViewModel(IVisitorService visitorService, IAddressService addressService)
    {
        _visitorService = visitorService;
        _addressService = addressService;
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
    }

    [RelayCommand]
    private void ZipCodeTextChanged()
    {
        AddressView!.Refresh();
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
            VisitorInterests =
            [
                CommonSelected,
                BfiSelected,
                SySelected,
                FwiSelected,
                WitSelected
            ]
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
    
    private bool CanSave()
    {
        return (CommonSelected || BfiSelected || SySelected || FwiSelected || WitSelected) 
               && SelectedAddress is not null ;
    }
}