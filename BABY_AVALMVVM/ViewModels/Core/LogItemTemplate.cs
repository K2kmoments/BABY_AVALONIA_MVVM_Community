using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using SQLite;

namespace BABY_AVALONIA_MVVM.ViewModels;

public class LogItemTemplate
{
    public LogItemTemplate()
    {
       
    }
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public string? IconPath { get; set; }
    public DateTime LogCreationDateTime { get; set; }
    public string? Duration { get; set; }
    public string? Note { get; set; }
    public string? IconKey { get; set; }
    
}