using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BABY_AVALMVVM.Models;
using BABY_AVALONIA_MVVM.ViewModels.Helper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BABY_AVALONIA_MVVM.ViewModels;

public partial class PooPooViewModel : ViewModelBase
{
    private readonly string _iconStringPooPoo ="M2.00244 4.70455V9C2.00244 12.3137 4.68873 15 8.00244 15C8.10042 15 8.19784 14.9977 8.29467 14.993C8.55723 15.8766 8.98958 16.6872 9.5539 17.3868L7.22374 19.7156C6.93075 20.0084 6.93061 20.4833 7.22342 20.7763C7.51622 21.0692 7.99109 21.0694 8.28408 20.7766L10.6146 18.4474C11.8152 19.4154 13.3421 19.9949 15.0044 19.9949C18.8696 19.9949 22.0031 16.8615 22.0031 12.9962V7.74756C22.0031 6.78106 21.2196 5.99756 20.2531 5.99756L15.0044 5.99756C14.4209 5.99756 13.8541 6.06896 13.3123 6.2035C12.3069 4.29847 10.3063 3 8.00244 3H3.70699C2.76559 3 2.00244 3.76315 2.00244 4.70455ZM11.6835 17.3792L15.7801 13.2851C16.0731 12.9923 16.0732 12.5174 15.7804 12.2244C15.4876 11.9314 15.0128 11.9313 14.7198 12.2241L10.6226 16.3188C9.92169 15.3958 9.50569 14.2446 9.50569 12.9962C9.50569 9.9594 11.9675 7.49756 15.0044 7.49756H20.2531C20.3911 7.49756 20.5031 7.60949 20.5031 7.74756V12.9962C20.5031 16.0331 18.0412 18.4949 15.0044 18.4949C13.7567 18.4949 12.6062 18.0794 11.6835 17.3792ZM8.00244 4.5C9.65903 4.5 11.1065 5.39514 11.8877 6.72812C10.7891 7.27543 9.85464 8.10307 9.17802 9.11737L7.28032 7.21967C6.98743 6.92678 6.51255 6.92678 6.21966 7.21967C5.92677 7.51256 5.92677 7.98744 6.21966 8.28033L8.45718 10.5179C8.1654 11.2883 8.00569 12.1236 8.00569 12.9962C8.00569 13.1656 8.01171 13.3336 8.02354 13.5L8.00244 13.5C5.51716 13.5 3.50244 11.4853 3.50244 9L3.50244 4.70455C3.50244 4.59158 3.59402 4.5 3.70699 4.5L8.00244 4.5Z";
    private readonly string _peepeeIcon;
    
    [ObservableProperty] private ObservableCollection<PooPooItem>? _pooPooItemList;
    
    private int maxItemsInCollection = 2;
   

    public PooPooViewModel()
    {
        PooPooItemList = new();
         _peepeeIcon = "/Assets/Pictures/water-drop_10703023.png"; 
    }
    

    [RelayCommand]
    private void PeeSelect()
    {
        var peeSelect = new PooPooItem("PeePee", _peepeeIcon);
        
        if((PooPooItemList.Count + 2) <= maxItemsInCollection)
        {
            PooPooItemList.Add(peeSelect);
        }
       
    }
    [RelayCommand]
    private void PooPooSelect()
    {
        
        var pooSelect = new PooPooItem("PooPoo", "/Assets/Pictures/water-drop_10703023.png");
        PooPooItemList?.Add(pooSelect);
    }
    
    [RelayCommand]
    private void SaveButtonPress()
    {
        
        var entryToSave = new LogItemTemplate()
        {
            Name = "PooPoo",
            Duration = "",
            Note = "",
            LogCreationDateTime = DateTime.Now,
            IconString = _iconStringPooPoo
                
        };
        
        SqLiteHelper.SaveToDatabase(entryToSave);
        SqLiteHelper.ReadFeedingLogEntriesFromDatabase();
        PooPooItemList?.Clear();
    }
    
}