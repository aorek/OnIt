using OnIt.Model;
using OnIt.MVVM;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;

namespace OnIt.Task.ViewModel
{
   public class MainWindowVM : NotifyPropertyChanged
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

      
   }
}
