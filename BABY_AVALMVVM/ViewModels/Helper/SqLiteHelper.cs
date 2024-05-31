using System;
using System.Collections.Generic;
using System.IO;
using BABY_AVALONIA_MVVM.Models;
using SQLite;

namespace BABY_AVALONIA_MVVM.ViewModels.Helper;

public static class SqLiteHelper
{
    #region DatabasePath

    private const string FileName = "BabyApp.db";
    private static readonly string DatabaseFolder = Environment.CurrentDirectory;
    private static readonly string DatabasePath = Path.Combine(DatabaseFolder, FileName);
    

    #endregion

   
    //public static BabyLogDatabaseEntry? FeedingLogEntry { get; set; }
    public static LogItemTemplate? LogItemTemplate { get; set; }

    public static void SaveToDatabase(LogItemTemplate babyLogDatabaseEntry)
    {
        
        using (SQLiteConnection connection = new SQLiteConnection(DatabasePath))
        {
            connection.CreateTable<LogItemTemplate>();
            connection.Insert(babyLogDatabaseEntry);
        }
    }

    public static void DeleteEntryInDatabase(LogItemTemplate selectedDatabaseEntry)
    {
        using (SQLiteConnection connection = new SQLiteConnection(DatabasePath))
        {
            connection.CreateTable<BabyLogDatabaseEntry>();
            connection.Delete(selectedDatabaseEntry);
        }
    }

    public static List<LogItemTemplate>? ReadFeedingLogEntriesFromDatabase()
    {
        
        List<LogItemTemplate>? feedingLogInTable;
        
        using (SQLiteConnection connection = new SQLiteConnection(DatabasePath))
        {
            connection.CreateTable<LogItemTemplate>();
            feedingLogInTable = connection.Table<LogItemTemplate>().ToList();
        }

        return feedingLogInTable;
    }


}