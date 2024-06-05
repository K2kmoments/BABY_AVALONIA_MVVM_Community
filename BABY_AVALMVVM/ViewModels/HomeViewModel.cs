using System.Collections.Generic;
using BABY_AVALONIA_MVVM.ViewModels.Core;
using BABY_AVALONIA_MVVM.ViewModels;
using BABY_AVALONIA_MVVM.ViewModels.Helper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BABY_AVALONIA_MVVM.ViewModels;

public partial class HomeViewModel : ViewModelBase
{

     [ObservableProperty] private List<LogItemTemplate>? _feedingDatabaseEntries;
     
     [ObservableProperty] private LogItemTemplate _selectedDatabaseEntry = null!;

     [RelayCommand]
     private void DeleteButton()
     {
          if (SelectedDatabaseEntry != null)
          {
               SqLiteHelper.DeleteEntryInDatabase(SelectedDatabaseEntry);
               //refresh
               RefreshDb();
          }

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