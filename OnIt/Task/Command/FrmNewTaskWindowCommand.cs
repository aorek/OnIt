using OnIt.BusinessLogic;
using OnIt.Helper;
using OnIt.Model;
using OnIt.MVVM;
using OnIt.Task.View;
using OnIt.Task.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OnIt.Task.Commands
{
   public class FrmNewTaskWindowCommand : FrmNewTaskWindowVM
   {
      #region Commands

      public ICommand AddTaskCommand { get; set; }
      public ICommand CancelCommand { get; set; }

      #endregion

      private TaskBL taskBL;
      public FrmNewTaskWindow frmNewTaskWindow;

      public FrmNewTaskWindowCommand(object window)
      {
         AddTaskCommand = new RelayCommand(AddTask);
         CancelCommand = new RelayCommand(Cancel);

         frmNewTaskWindow = (FrmNewTaskWindow)window;

         taskBL = new TaskBL(Helper.ConnectionStringSingleton.Instance.ConnectionString);
      }

      private void AddTask()
      {
         if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(DueDate))
         {
            MessageBox.Show("Required fields can not be empty", Enums.MessageTypes.Error.ToString(), MessageBoxButton.OK);
            return;
         }

         try
         {
            var task = new TaskModel()
            {
               Title = this.Title,
               Description = this.Description,
               DueDate = DateTime.ParseExact(this.DueDate, "dd/MM/yyyy", CultureInfo.CurrentCulture),
               CreationDate = DateTime.Now
            };

            if (taskBL.Create(task))
            {
               if (MessageBox.Show("Task added correctly", Enums.MessageTypes.Success.ToString(), MessageBoxButton.OK) == MessageBoxResult.OK);
                  Cancel();
            }
            else
            {
               MessageBox.Show("Something went wrong", Enums.MessageTypes.Error.ToString(), MessageBoxButton.OK);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString(), Enums.MessageTypes.Error.ToString(), MessageBoxButton.OK);
            throw ex;
         }
      }

      private void Cancel()
      {
         frmNewTaskWindow.Close();
      }
   }
}
