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
      public ICommand FilterCommand { get; set; }

      #endregion

      private TaskBL taskBL;

      public MainWindowCommand()
      {
         taskBL = new TaskBL(ConnectionStringSingleton.Instance.ConnectionString);
         Tasks = new ObservableCollection<TaskModel>(taskBL.GetAll());

         NewTaskCommand = new RelayCommand(NewTask);
         EditTaskCommand = new RelayCommand(EditTask);
         CompleteTaskCommand = new RelayCommand(CompleteTask);
         DeleteTaskCommand = new RelayCommand(DeleteTask);
         FilterCommand = new RelayCommand(FilterTask);
      }

      private void CompleteTask(object o)
      {
         var taskList = o as System.Windows.Controls.ListBox;
         if (taskList.Items == null || taskList.Items.Count <= 0)
            return;

         var selectedTask = (TaskModel)taskList.SelectedItem;
         taskBL.SetState(selectedTask.IdTask);
         RefreshByFilter();
      }

      private void NewTask(object o)
      {
         FrmNewEditTaskWindow newtaskWindow = new FrmNewEditTaskWindow();
         newtaskWindow.ShowDialog();
         RefreshByFilter();
      }

      private void EditTask(object o)
      {
         var taskList = o as System.Windows.Controls.ListBox;

         if (taskList.Items == null || taskList.Items.Count <= 0)
            return;

         var selectedTask = (TaskModel)taskList.SelectedItem;
         FrmNewEditTaskWindow newtaskWindow = new FrmNewEditTaskWindow(selectedTask.IdTask);
         newtaskWindow.ShowDialog();
         RefreshByFilter();
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
            RefreshByFilter();
         }
      }

      private void FilterTask(object o)
      {
         var control = o as System.Windows.Controls.MenuItem;

         if (control == null)
            return;

         Filter = (string)control.Header;

         RefreshByFilter();
      }

      private void RefreshByFilter()
      {
         switch (Filter)
         {
            default:
            case "All":
               GetAllTask();
               break;
            case "Active":
            case "Completed":
               GetByFilter(Filter);
               break;
         }
      }

      private void GetAllTask()
      {
         Tasks = new ObservableCollection<TaskModel>(taskBL.GetAll());
      }

      private void GetByFilter(string filter)
      {
         Tasks = new ObservableCollection<TaskModel>(taskBL.GetByFilter(filter));
      }
   }
}
