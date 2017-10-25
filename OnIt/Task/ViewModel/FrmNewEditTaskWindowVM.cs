using OnIt.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.Task.ViewModel
{
   public class FrmNewEditTaskWindowVM : NotifyPropertyChanged
   {
      private string titleWindow;
      public string TitleWindow
      {
         get { return titleWindow; }
         set
         {
            if (value != titleWindow)
            {
               titleWindow = value;
               OnPropertyChanged(nameof(TitleWindow));
            }
         }
      }

      private int? idTask;
      public int? IdTask
      {
         get { return idTask; }
         set
         {
            if (value != idTask)
            {
               idTask = value;
               OnPropertyChanged(nameof(IdTask));
            }
         }
      }

      private string title;
      public string Title
      {
         get { return title; }
         set
         {
            if (value != title)
            {
               title = value;
               OnPropertyChanged(nameof(Title));
            }
         }
      }

      private string description;
      public string Description
      {
         get { return description; }
         set
         {
            if (value != description)
            {
               description = value;
               OnPropertyChanged(nameof(Description));
            }
         }
      }

      private string dueDate;
      public string DueDate
      {
         get { return dueDate; }
         set
         {
            if (value != dueDate)
            {
               dueDate = value;
               OnPropertyChanged(nameof(DueDate));
            }
         }
      }
   }
}
