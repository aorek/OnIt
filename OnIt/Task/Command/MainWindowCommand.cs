using OnIt.BusinessLogic;
using OnIt.Helper;
using OnIt.Model;
using OnIt.MVVM;
using OnIt.Task.View;
using OnIt.Task.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OnIt.Task.Command
{
   public class MainWindowCommand : MainWindowVM
   {
      #region Commands

      public ICommand NewTaskCommand { get; set; }
      public ICommand EditTaskCommand { get; set; }
      public ICommand CompleteTaskCommand { get; set; }
      public ICommand DeleteTaskCommand { get; set; }

      #endregion

      private TaskBL taskBL;

      public MainWindowCommand()
      {
         taskBL = new TaskBL(Helper.ConnectionStringSingleton.Instance.ConnectionString);
         Tasks = new ObservableCollection<TaskModel>(taskBL.GetAll());

         NewTaskCommand = new RelayCommand(NewTask);
         CompleteTaskCommand = new RelayCommand(CompleteTask);
         DeleteTaskCommand = new RelayCommand(DeleteTask);
      }

      private void CompleteTask(object o)
      {
         var taskList = o as System.Windows.Controls.ListBox;

         if (taskList.Items == null || taskList.Items.Count <= 0)
            return;

         var selectedTask = (TaskModel)taskList.SelectedItem;


      }

      private void NewTask(object o)
      {
         FrmNewTaskWindow newtaskWindow = new FrmNewTaskWindow();
         newtaskWindow.ShowDialog();
         RefreshData();
      }

      private void DeleteTask(object o)
      {
         var taskList = o as System.Windows.Controls.ListBox;

         if (taskList.Items == null || taskList.Items.Count <= 0)
            return;

         var selectedTask = (TaskModel)taskList.SelectedItem;

         if (MessageBox.Show($"Do you want to delete the task '{selectedTask.Title}' ?", Enums.MessageTypes.Information.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
         {
            taskBL.Delete(selectedTask.IdTask);
            RefreshData();
         }
      }

      private void RefreshData()
      {
         Tasks = new ObservableCollection<TaskModel>(taskBL.GetAll());
      }
   }
}
