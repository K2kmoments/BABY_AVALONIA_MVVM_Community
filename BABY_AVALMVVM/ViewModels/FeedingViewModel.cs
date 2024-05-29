using System;
using BABY_AVALONIA_MVVM.Models;
using BABY_AVALONIA_MVVM.ViewModels.Helper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BABY_AVALONIA_MVVM.ViewModels;

public partial class FeedingViewModel : ViewModelBase
{
    
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
        
        
        var entryToSave = new BabyLogDatabaseEntry()
        {
            Name = "Feeding",
            FullDurationFed = BigSumTimerTextBlock,
            LastSideFed = LastSideFedString,
            LogCreationDateTime = DateTime.Now,
            
            
        };
        
        SqLiteHelper.SaveToDatabase(entryToSave);
        SqLiteHelper.ReadFeedingLogEntriesFromDatabase();

    }
}