using OnIt.BusinessLogic;
using OnIt.Model;
using OnIt.MVVM;
using OnIt.View;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;

namespace OnIt.ViewModel
{
   public class MainViewModel : NotifyPropertyChanged
   {
      #region Commands

      public ICommand NewTaskCommand { get; set; }

      # endregion

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

         NewTaskCommand = new RelayCommand(NewTask);
      }

      private void NewTask()
      {
         FrmNewTaskWindow newtaskWindow = new FrmNewTaskWindow();
         newtaskWindow.ShowDialog();
      }
   }
}
