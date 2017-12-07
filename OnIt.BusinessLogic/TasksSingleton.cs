using OnIt.Helper;
using OnIt.Model;
using OnIt.Model.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.BusinessLogic
{
   public class TasksSingleton
   {
      public ObservableCollection<TaskModel> Tasks { get; set; }

      private static TasksSingleton instance;
      public static TasksSingleton Instance
      {
         get
         {
            if (instance == null)
               instance = new TasksSingleton();
            return instance;
         }
      }
   }
}
