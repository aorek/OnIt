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
   public class TaskBL
   {
      internal OnItDbContext context;
      internal string connectionString;
      private RepositoryData<TaskModel> repo;

      public TaskBL(string connectionString)
      {
         this.connectionString = connectionString;
         context = new OnItDbContext(connectionString);
         repo = new RepositoryData<TaskModel>(context);
      }

      public IEnumerable<TaskModel> GetAll()
      {
         return repo.GetAll();
      }

      public object GetById(int idTask)
      {
         var task = new TaskModel();

         task = repo.GetById(idTask);
         return task;
      }

      public ObservableCollection<TaskModel> GetByFilter(string filter)
      {
         return new ObservableCollection<TaskModel>(TasksSingleton.Instance.Tasks.Where(t => t.State.ToString() == filter).OrderBy(t => t.DueDate)); ;
      }

      public bool Create(TaskModel task)
      {
         try
         {
            if (repo.Create(task))
               TasksSingleton.Instance.Tasks.Add(task);

            return true;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void Delete(int idTask)
      {
         try
         {
            if (repo.Delete(idTask))
            {
               var taskToDelete = TasksSingleton.Instance.Tasks.Where(t => t.IdTask == idTask).FirstOrDefault();
               TasksSingleton.Instance.Tasks.Remove(taskToDelete);
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void Delete(List<int> idTaskList)
      {
         idTaskList.ForEach(idTask => Delete(idTask));
      }

      private void SetState(int id)
      {
         var model = GetById(id);
         var modifiedModel = model.CloneObject<TaskModel>();

         if (modifiedModel.State == Enums.StateTypes.Active)
            modifiedModel.State = Enums.StateTypes.Completed;
         else
            modifiedModel.State = Enums.StateTypes.Active;

         Update(id, modifiedModel);
      }

      public void SetState(List<int> idTaskList)
      {
         idTaskList.ForEach(idTask => SetState(idTask));
      }

      public void Reload<TModel>(TModel entity) where TModel : class
      {
         context.Entry(entity).Reload();
      }

      public bool Update(int idTask, TaskModel modifiedModel)
      {
         var model = (TaskModel)GetById(idTask);
         try
         {
            if (repo.Update(model, modifiedModel))
            {
               var originalTaskIndex = TasksSingleton.Instance.Tasks.IndexOf(TasksSingleton.Instance.Tasks.Where(t => t.IdTask == idTask).FirstOrDefault());
               TasksSingleton.Instance.Tasks[originalTaskIndex] = modifiedModel;
            }

            return true;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }
}
