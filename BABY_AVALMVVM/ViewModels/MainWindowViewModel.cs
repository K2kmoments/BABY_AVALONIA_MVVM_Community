using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BABY_AVALONIA_MVVM.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   
   
   
   //Alle Pages der Collection Hinzufügen:
   public ObservableCollection<NavItemTemplate> PagesInNavigation { get; } = new()
   {
      new NavItemTemplate(typeof(HomeViewModel),"Home", "HomeRegular"), 
      new NavItemTemplate(typeof(FeedingViewModel),"Feeding","FoodRegular"),
      new NavItemTemplate(typeof(PooPooViewModel),"PooPoo","PooPooIcon"),
      new NavItemTemplate(typeof(SleepViewModel),"Sleep","SleepRegular"),
      new NavItemTemplate(typeof(ExerciseViewModel),"Exercise","ExerciseIcon"),
      new NavItemTemplate(typeof(DoctorViewModel),"Doctor","DoctorVisits"),
      new NavItemTemplate(typeof(PhotoViewModel),"Photo","ImageAddRegular"),
      
   };

   [ObservableProperty] private NavItemTemplate? _selectedListItem;
   [ObservableProperty] private ViewModelBase _currentPage = new HomeViewModel();
   [ObservableProperty] private bool _isPanelOpen = true;

   [RelayCommand]
   private void TriggerPane()
   {
      IsPanelOpen = !IsPanelOpen;
   }

   partial void OnSelectedListItemChanged(NavItemTemplate? value)
   {
      if(value is null) return;
      var instance = Activator.CreateInstance(value.ModelType);
      if(instance is null) return;
      CurrentPage = (ViewModelBase)instance;
   }

}