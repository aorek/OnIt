using OnIt.Helper;
using OnIt.Model;
using OnIt.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.BusinessLogic
{
   public class TaskBL
   {
      internal OnItDbContext context;
      internal string connectionString;

      public TaskBL(string connectionString)
      {
         this.connectionString = connectionString;
         context = new OnItDbContext(connectionString);
      }

      public List<TaskModel> GetAll()
      {
         var taskList = new List<TaskModel>();
         var repo = new RepositoryData<TaskModel>(context);

         taskList = repo.GetAll().ToList();
         return taskList;
      }

      public object GetById(int idTask)
      {
         var task = new TaskModel();
         var repo = new RepositoryData<TaskModel>(context);

         task = repo.GetById(idTask);
         return task;
      }

      public List<TaskModel> GetByFilter(string filter)
      {
         var alltaskList = new List<TaskModel>();
         var taskList = new List<TaskModel>();
         alltaskList = GetAll();
         taskList = alltaskList.Where(t => t.State.ToString() == filter).ToList();
         
         return taskList;
      }

      public bool Create(TaskModel task)
      {
         var repo = new RepositoryData<TaskModel>(context);
         try
         {
            repo.Create(task);
            return true;
         }
         catch (Exception)
         {
            return false;
         }
      }

      public bool Delete(int idTask)
      {
         var repo = new RepositoryData<TaskModel>(context);
         try
         {
            repo.Delete(idTask);
            return true;
         }
         catch (Exception)
         {
            return false;
         }
      }

      public void SetState(int id)
      {
         var model = GetById(id);
         var modifiedModel = model.CloneObject<TaskModel>() ;

         if (modifiedModel.State == Enums.StateTypes.Active)
            modifiedModel.State = Enums.StateTypes.Completed;
         else
            modifiedModel.State = Enums.StateTypes.Active;

         Update(id, modifiedModel);
      }

      public void Reload<TModel>(TModel entity) where TModel : class
      {
         context.Entry(entity).Reload();
      }

      public bool Update(int idTask, TaskModel modifiedModel)
      {
         var repo = new RepositoryData<TaskModel>(context);
         var model = (TaskModel)GetById(idTask);
         try
         {
            repo.Update(model, modifiedModel);
            Reload(model);
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }
   }
}
