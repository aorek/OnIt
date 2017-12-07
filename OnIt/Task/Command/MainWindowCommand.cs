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
         TasksSingleton.Instance.Tasks = new ObservableCollection<TaskModel>(taskBL.GetAll().OrderBy(t => t.DueDate));
         Tasks = TasksSingleton.Instance.Tasks;

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

         var selectedTasks = taskList.SelectedItems.Cast<TaskModel>();
         taskBL.SetState(selectedTasks.Select(task => task.IdTask).ToList());
         RefreshByFilter();
      }

      private void NewTask(object o)
      {
         FrmNewEditTaskWindow newtaskWindow = new FrmNewEditTaskWindow();
         newtaskWindow.ShowDialog();
         RefreshByFilter();
      }

      public void EditTask(object o)
      {
         var taskList = o as System.Windows.Controls.ListBox;

         if (taskList.Items == null || taskList.Items.Count <= 0)
            return;

         if (taskList.SelectedItems.Count > 1)
         {
            MessageBox.Show("You can not edit multiple tasks at the same time", Enums.MessageTypes.Information.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return;
         }

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

         var selectedTasks = taskList.SelectedItems.Cast<TaskModel>();

         bool result = false;
         if (selectedTasks.Count() > 1)
            result = MessageBox.Show("Do you want to delete the selected tasks ?", Enums.MessageTypes.Information.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
         else if (selectedTasks.Count() == 1)
            result = MessageBox.Show($"Do you want to delete the task '{selectedTasks.FirstOrDefault().Title}' ?", Enums.MessageTypes.Information.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;

         if (result)
         {
            taskBL.Delete(selectedTasks.Select(task => task.IdTask).ToList());
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
         Tasks = new ObservableCollection<TaskModel>(TasksSingleton.Instance.Tasks.OrderBy(t => t.DueDate));
      }

      private void GetByFilter(string filter)
      {
         Tasks = taskBL.GetByFilter(filter);
      }
   }
}
