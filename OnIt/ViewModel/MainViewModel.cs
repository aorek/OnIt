using OnIt.BusinesLogic;
using OnIt.Model;
using OnIt.MVVM;
using System;
using System.Collections.ObjectModel;
using System.Configuration;

namespace OnIt.ViewModel
{
   public class MainViewModel : NotifyPropertyChanged
   {
      private TaskBL taskBL;

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
         string connectionString = ConfigurationManager.ConnectionStrings["OnitDbContext"].ConnectionString;
         taskBL = new TaskBL(connectionString);
         Tasks = new ObservableCollection<TaskModel>(taskBL.GetData());
      }
   }
}
