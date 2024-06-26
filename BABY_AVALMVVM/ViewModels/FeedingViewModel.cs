using System;
using BABY_AVALONIA_MVVM.ViewModels.Core;
using BABY_AVALONIA_MVVM.ViewModels.Helper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BABY_AVALONIA_MVVM.ViewModels;

public partial class FeedingViewModel : ViewModelBase
{
    private string _iconStringFeeding = "M18.25,3.25 C18.6296958,3.25 18.943491,3.53215388 18.9931534,3.89822944 L19,4 L19,20 C19,20.4142136 18.6642136,20.75 18.25,20.75 C17.8703042,20.75 17.556509,20.4678461 17.5068466,20.1017706 L17.5,20 L17.5,15 L15.25,15 C14.8703042,15 14.556509,14.7178461 14.5068466,14.3517706 L14.5,14.25 L14.5,7 C14.5,4.92893219 16.1789322,3.25 18.25,3.25 Z M12.25,3.25 C12.6296958,3.25 12.943491,3.53215388 12.9931534,3.89822944 L13,4 L13,8 C13,9.95258026 11.6009489,11.5783946 9.75060185,11.9296879 L9.75,20 C9.75,20.4142136 9.41421356,20.75 9,20.75 C8.62030423,20.75 8.30650904,20.4678461 8.25684662,20.1017706 L8.25,20 L8.25039462,11.9298769 C6.46565489,11.5915104 5.10054372,10.0674505 5.00531224,8.20794855 L5,8 L5,4 C5,3.58578644 5.33578644,3.25 5.75,3.25 C6.12969577,3.25 6.44349096,3.53215388 6.49315338,3.89822944 L6.5,4 L6.5,8 C6.5,9.11956531 7.23592684,10.0672457 8.25042097,10.3856816 L8.25,4 C8.25,3.58578644 8.58578644,3.25 9,3.25 C9.37969577,3.25 9.69349096,3.53215388 9.74315338,3.89822944 L9.75,4 L9.75057321,10.3853693 C10.7082217,10.0843344 11.4174241,9.22252883 11.4932687,8.18486443 L11.5,8 L11.5,4 C11.5,3.58578644 11.8357864,3.25 12.25,3.25 Z M17.5,13.5 L17.5,4.87802928 C16.6775113,5.16873733 16.0745169,5.92410043 16.0064224,6.82871311 L16,7 L16,13.5 L17.5,13.5 L17.5,4.87802928 L17.5,13.5 Z";
    public FeedingViewModel()
    {
        _feedingStopwatch = new BreastFeedingStopwatch(this);
    }

    private readonly BreastFeedingStopwatch _feedingStopwatch;
    
    [ObservableProperty] private string _bigSumTimerTextBlock = "00:00";
    [ObservableProperty] private string _leftTimerButtonText = "Start";
    [ObservableProperty] private string _rightTimerButtonText = "Start";
    [ObservableProperty] private TimeSpan _totalTimeFeeded;
    public string? LastSideFedString {
        get;
        set;
    }
    

    [RelayCommand]
    private void LeftButtonPress()
    {
        _feedingStopwatch.LeftBreastTimer(); 
    }

    [RelayCommand]
    private void RightButtonPress()
    {
        _feedingStopwatch.RightBreastTimer();
    }

    [RelayCommand]
    private void SaveButtonPress()
    {
        _feedingStopwatch.Stop();
        
        var entryToSave = new LogItemTemplate()
        {
            Name = "Feeding",
            Duration = BigSumTimerTextBlock,
            Note = LastSideFedString,
            LogCreationDateTime = DateTime.Now,
            IconString = _iconStringFeeding
                
        };
        
        SqLiteHelper.SaveToDatabase(entryToSave);
        SqLiteHelper.ReadFeedingLogEntriesFromDatabase();

    }
}