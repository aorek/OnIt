using OnIt.BusinessLogic;
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
using System.Windows.Input;

namespace OnIt.Task.Command
{
    public class MainWindowCommand : MainWindowVM
    {
      #region Commands

      public ICommand NewTaskCommand { get; set; }
      public ICommand DeleteTaskCommand { get; set; }

      #endregion

      private TaskBL taskBL;

      public MainWindowCommand()
      {
         taskBL = new TaskBL(Helper.ConnectionStringSingleton.Instance.ConnectionString);
         Tasks = new ObservableCollection<TaskModel>(taskBL.GetAll());

         NewTaskCommand = new RelayCommand(NewTask);
         DeleteTaskCommand = new RelayCommand(DeleteTask);
      }

      private void DeleteTask(object o)
      {
         RefreshData();
      }

      private void NewTask(object o)
      {
         FrmNewTaskWindow newtaskWindow = new FrmNewTaskWindow();
         newtaskWindow.ShowDialog();
         RefreshData();
      }

      private void RefreshData()
      {
         Tasks = new ObservableCollection<TaskModel>(taskBL.GetAll());
      }
   }
}
