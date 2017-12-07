using OnIt.BusinessLogic;
using OnIt.Helper;
using OnIt.Model;
using OnIt.MVVM;
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
   public class FrmNewEditTaskWindowCommand : FrmNewEditTaskWindowVM
   {
      #region Commands

      public ICommand AcceptCommand { get; set; }
      public ICommand CancelCommand { get; set; }

      #endregion

      private TaskBL taskBL;

      public FrmNewEditTaskWindowCommand(int? modelId)
      {
         AcceptCommand = new RelayCommand(CreateAOrUpdateTask);
         CancelCommand = new RelayCommand(Cancel);

         taskBL = new TaskBL(ConnectionStringSingleton.Instance.ConnectionString);

         IdTask = modelId;

         if (IdTask.HasValue)
         {
            TitleWindow = "Edit task";
            FillFields();
         }
         else
            TitleWindow = "New task";
      }

      private void Cancel(object o)
      {
         if (o is Window)
         {
            var auxWindow = o as Window;
            auxWindow.Close();
         }
      }

      private void CreateAOrUpdateTask(object o)
      {
         if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(DueDate))
         {
            MessageBox.Show("Required fields can not be empty", Enums.MessageTypes.Warning.ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
         }

         try
         {
            var task = new TaskModel()
            {
               IdTask = (IdTask.HasValue ? (int)this.IdTask : 0),
               Title = this.Title,
               Description = this.Description,
               State = Enums.StateTypes.Active,
               DueDate = DateTime.ParseExact(this.DueDate, "dd/MM/yyyy", CultureInfo.CurrentCulture),
               CreationDate = DateTime.Now
            };

            if (!IdTask.HasValue)
            {
               if (taskBL.Create(task))
               {
                  MessageBox.Show("Task added correctly", Enums.MessageTypes.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
                  Cancel(o);
               }
               else
               {
                  MessageBox.Show("Something went wrong", Enums.MessageTypes.Warning.ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
               }
            }
            else
            {
               if (taskBL.Update((int)IdTask, task))
               {
                  MessageBox.Show("Task update correctly", Enums.MessageTypes.Success.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
                  Cancel(o);
               }
               else
               {
                  MessageBox.Show("Something went wrong", Enums.MessageTypes.Warning.ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Enums.MessageTypes.Error.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            return;
         }
      }

      private void FillFields()
      {
         var idTask = (int)IdTask;
         var vModel = (TaskModel)taskBL.GetById(idTask);

         if (vModel != null)
         {
            Title = vModel.Title;
            Description = vModel.Description;
            DueDate = vModel.DueDate.ToString("dd/MM/yyyy");
         }
      }
   }
}
