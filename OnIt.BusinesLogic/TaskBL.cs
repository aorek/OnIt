using OnIt.Model;
using OnIt.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.BusinesLogic
{
   public class TaskBL : BaseBL
   {
      public TaskBL(string connectionString) : base(connectionString)
      {
      }

      public List<TaskModel> GetData()
      {
         var repo = new RepositoryData<TaskModel>(context);
         return repo.GetData().ToList();
      }
   }
}
