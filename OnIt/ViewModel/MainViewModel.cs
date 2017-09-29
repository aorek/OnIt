using OnIt.Model;
using OnIt.MVVM;
using System;
using System.Collections.ObjectModel;

namespace OnIt.ViewModel
{
   public class MainViewModel : NotifyPropertyChanged
   {
      private ObservableCollection<TaskModel> tasks;

      public ObservableCollection<TaskModel> Tasks
      {
         get { return tasks; }
         set
         {
            if (value != tasks)
            {
               tasks = value;
               OnPropertyChanged(nameof(Tasks));
            }
         }
      }

      public MainViewModel()
      {
         
      }
   }
}
