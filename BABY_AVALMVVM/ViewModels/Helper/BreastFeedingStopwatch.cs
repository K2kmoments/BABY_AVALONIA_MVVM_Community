using System;
using System.Diagnostics;
using System.Timers;
using Avalonia.Threading;

namespace BABY_AVALONIA_MVVM.ViewModels.Helper;

public class BreastFeedingStopwatch
{
    public FeedingViewModel Vm { get; set; }
   
    //LEFT
    private readonly Stopwatch _stopwatchLeft;
    private readonly Timer _timerLeft;

    //RIGHT Backing
    private readonly Stopwatch _stopwatchRight;
    private readonly Timer _timerRight;
    
    //Properties 
    public string? MainTimeDisplayString { get; private set; }
    public string? LeftTimerString { get; private set; } = "00:00";
    public string? RightTimerString { get; private set; }
    private TimeSpan TotalTimeFeeded { get; set; }

    public BreastFeedingStopwatch(FeedingViewModel vm)
    {
        //Initialize LEFT TimerComponents
        _stopwatchLeft = new Stopwatch();
        _timerLeft = new Timer(1000);
        _timerLeft.Elapsed += OnTimerLeftElapsed;
        
        //Initialize Right TimerComponents
        _stopwatchRight = new Stopwatch();
        _timerRight = new Timer(1000);
        _timerRight.Elapsed += OnTimerRightElapsed;
        
        //FeedingViewModel
        Vm = vm;
        
    }
    
    public void LeftBreastTimer()
    {
        if (!_stopwatchLeft.IsRunning)
        {
            
            if(_stopwatchRight.IsRunning){_stopwatchRight.Stop();}
            
            _stopwatchLeft.Start();
            _timerLeft.Start();
            Vm.LastSideFedString = "Left was last Side";
        }
        else
        {
            _stopwatchLeft.Stop();
            Vm.LeftTimerButtonText = "Stopped";
            
        }
       
    }
    public void RightBreastTimer()
    {
        if (!_stopwatchRight.IsRunning)
        {
            if(_stopwatchLeft.IsRunning){_stopwatchLeft.Stop();}
            
            _stopwatchRight.Start();
            _timerRight.Start();
            Vm.LastSideFedString = "Right was last Side";
        }
        else
        {
            _stopwatchRight.Stop();
            Vm.RightTimerButtonText = "Stopped";
        }
       
    }

    public void Stop()
    {
        _stopwatchRight.Stop();
        _timerRight.Stop();
        _stopwatchLeft.Stop();
        _timerLeft.Stop();
    }
    private void OnTimerLeftElapsed(object? sender, ElapsedEventArgs e)
    {
        Dispatcher.UIThread.Invoke(() =>
        {
            //Timespan
            TotalTimeFeeded = (_stopwatchLeft.Elapsed + _stopwatchRight.Elapsed);
            
            //Strings
            LeftTimerString = _stopwatchLeft.Elapsed.ToString(@"mm\:ss"); // (@"hh\:mm\:ss")
            MainTimeDisplayString = TotalTimeFeeded.ToString(@"mm\:ss");
            
            //Bind To ViewModelProperties:
            Vm.LeftTimerButtonText = LeftTimerString;
            Vm.BigSumTimerTextBlock = MainTimeDisplayString;
            Vm.TotalTimeFeeded = TotalTimeFeeded;

        });
    }

    private void OnTimerRightElapsed(object? sender, ElapsedEventArgs e)
    {
        Dispatcher.UIThread.Invoke(() =>
        { 
            //TimeSpan
            TotalTimeFeeded = (_stopwatchLeft.Elapsed + _stopwatchRight.Elapsed);
            
            //Strings
            RightTimerString = _stopwatchRight.Elapsed.ToString(@"mm\:ss");
            MainTimeDisplayString = TotalTimeFeeded.ToString(@"mm\:ss");
            
            //Bind To ViewModelProperties:
            Vm.RightTimerButtonText = RightTimerString;
            Vm.BigSumTimerTextBlock = MainTimeDisplayString;
            Vm.TotalTimeFeeded = TotalTimeFeeded;
        });
    }

}