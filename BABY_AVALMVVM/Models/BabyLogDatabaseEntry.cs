using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using SQLite;

namespace BABY_AVALONIA_MVVM.Models;

public class BabyLogDatabaseEntry 
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public DateTime LogCreationDateTime { get; set; }
    [Indexed]
    public string Name { get; set; } = "Feeding";
    public string? FullDurationFed { get; set; }
    public string? LastSideFed { get; set; }
   
 
}