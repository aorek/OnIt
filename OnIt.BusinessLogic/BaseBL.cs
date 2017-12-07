using OnIt.Model;
using OnIt.Model.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.BusinessLogic
{
   //public class BaseBL
   //{
   //   internal OnItDbContext context;
   //   internal string connectionString;

   //   public BaseBL(string connectionString)
   //   {
   //      this.connectionString = connectionString;
   //      context = new OnItDbContext(connectionString);
   //   }

   //   public TModel Create<TModel>(TModel model) where TModel : class, new()
   //   {
   //      var repo = new RepositoryData<TModel>(context);
   //      try
   //      {
   //         repo.Create(model)
   //         return GetById<TModel>();
   //      }
   //      catch (Exception)
   //      {
   //         return null;
   //      }
   //   }

   //   public TModel GetById<TModel>(int id) where TModel : class, new()
   //   {
   //      var repo = new RepositoryData<TModel>(context);
   //      var newTModel = new TModel();

   //      newTModel = repo.GetById(id);
   //      return newTModel;
   //   }

   //   public void Reload<TModel>(TModel entity) where TModel : class
   //   {
   //      context.Entry(entity).Reload();
   //   }

   //   public TModel Update<TModel>(int idModel, TModel modifiedModel) where TModel : class, new()
   //   {
   //      var repo = new RepositoryData<TModel>(context);
   //      var model = GetById<TModel>(idModel);
   //      try
   //      {
   //         repo.Update(model, modifiedModel);
   //         Reload(model);
   //         return repo.GetById(idModel);
   //      }
   //      catch (Exception)
   //      {
   //         return null;
   //      }
   //   }
   //}
}
