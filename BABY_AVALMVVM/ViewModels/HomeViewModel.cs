using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Avalonia.Controls;
using BABY_AVALONIA_MVVM.Models;
using BABY_AVALONIA_MVVM.ViewModels.Helper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BABY_AVALONIA_MVVM.ViewModels;

public partial class HomeViewModel : ViewModelBase
{

     [ObservableProperty] private List<BabyLogDatabaseEntry>? _feedingDatabaseEntries;
     
     [ObservableProperty] private BabyLogDatabaseEntry _selectedDatabaseEntry = null!;

     [RelayCommand]
     private void DeleteButton()
     {
          SqLiteHelper.DeleteEntryInDatabase(SelectedDatabaseEntry);
          //refresh
          RefreshDb();
     }

     private void RefreshDb()
     {
          FeedingDatabaseEntries = SqLiteHelper.ReadFeedingLogEntriesFromDatabase();
     }
     public HomeViewModel()
     {
         RefreshDb();
     }
}