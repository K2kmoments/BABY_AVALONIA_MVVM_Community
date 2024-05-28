using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using Avalonia.Threading;

namespace BABY_AVALMVVM.ViewModels.Helper;

public partial class FeedingStopwatch    
{
    //LEFT
    private static readonly Stopwatch StopwatchLeft;
    private static readonly Timer TimerLeft;

    //RIGHT Backing
    private static readonly Stopwatch StopwatchRight;
    private static readonly Timer TimerRight;
    
    //Properties 
    public static string? MainTimeDisplayString { get; private set; }
    public static string? LeftTimerString { get; private set; } = "00:00";
    public static string? RightTimerString { get; private set; }
    private static TimeSpan TotalTimeFeeded { get; set; }

    static FeedingStopwatch()
    {
        //LEFT
        StopwatchLeft = new Stopwatch();
        TimerLeft = new Timer(1000);
        TimerLeft.Elapsed += OnTimerLeftElapsed;
        
        //RIGHT
        StopwatchRight = new Stopwatch();
        TimerRight = new Timer(1000);
        TimerRight.Elapsed += OnTimerRightElapsed;
    }

    public static void StartLeft()
    {
        StopwatchLeft.Start();
        TimerLeft.Start();
    }
    
    private static void OnTimerLeftElapsed(object? sender, ElapsedEventArgs e)
    {
        Dispatcher.UIThread.Invoke(() =>
        {
            //Timespan
            TotalTimeFeeded = (StopwatchLeft.Elapsed + StopwatchRight.Elapsed);
            //Strings
            LeftTimerString = StopwatchLeft.Elapsed.ToString(@"mm\:ss"); // (@"hh\:mm\:ss")
            MainTimeDisplayString = TotalTimeFeeded.ToString(@"mm\:ss");
        });
    }
    private static void OnTimerRightElapsed(object? sender, ElapsedEventArgs e)
    {
        Dispatcher.UIThread.Invoke(() =>
        { 
            //TimeSpan
            TotalTimeFeeded = (StopwatchLeft.Elapsed + StopwatchRight.Elapsed);
            //Strings
            RightTimerString = StopwatchRight.Elapsed.ToString(@"mm\:ss");
            MainTimeDisplayString = TotalTimeFeeded.ToString(@"mm\:ss");
        });
    }

}