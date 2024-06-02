using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using BABY_AVALONIA_MVVM.Models;
using SQLite;

namespace BABY_AVALONIA_MVVM.ViewModels;

public class LogItemTemplate
{
   [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public string? IconPath { get; set; }
    public DateTime LogCreationDateTime { get; set; }
    public string? Duration { get; set; }
    public string? Note { get; set; }
    public string? IconString { get; set; }

    public KindOfEnum KindOfLog { get; set; }
    
}