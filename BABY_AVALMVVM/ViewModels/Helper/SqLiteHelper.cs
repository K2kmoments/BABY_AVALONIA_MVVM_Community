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

   
    public static BabyLogDatabaseEntry? FeedingLogEntry { get; set; }

    public static void SaveToDatabase(BabyLogDatabaseEntry babyLogDatabaseEntry)
    {
        
        using (SQLiteConnection connection = new SQLiteConnection(DatabasePath))
        {
            connection.CreateTable<BabyLogDatabaseEntry>();
            connection.Insert(babyLogDatabaseEntry);
        }
    }

    public static void DeleteEntryInDatabase(BabyLogDatabaseEntry selectedDatabaseEntry)
    {
        using (SQLiteConnection connection = new SQLiteConnection(DatabasePath))
        {
            connection.CreateTable<BabyLogDatabaseEntry>();
            connection.Delete(selectedDatabaseEntry);
        }
    }

    public static List<BabyLogDatabaseEntry>? ReadFeedingLogEntriesFromDatabase()
    {
        
        
        List<BabyLogDatabaseEntry>? feedingLogInTable;
        

        using (SQLiteConnection connection = new SQLiteConnection(DatabasePath))
        {
            connection.CreateTable<BabyLogDatabaseEntry>();
            feedingLogInTable = connection.Table<BabyLogDatabaseEntry>().ToList();
        }

        return feedingLogInTable;
    }


}