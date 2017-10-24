using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.Model.Repository
{
   public class RepositoryData<TModel> where TModel : class
   {
      protected DbContext DbContext { get; set; }
      protected DbSet<TModel> DbSet { get; set; }
      protected bool AutoCommit { get; set; }

      public RepositoryData(OnItDbContext dbConext, bool autoCommit = true)
      {
         DbContext = dbConext;
         AutoCommit = autoCommit;
         DbSet = DbContext.Set<TModel>();
      }

      public void Create(TModel entity)
      {
         try
         {
            DbSet.Add(entity);

            if (AutoCommit)
               DbContext.SaveChanges();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void Delete(TModel entity)
      {
         try
         {
            DbSet.Attach(entity);
            DbSet.Remove(entity);

            if (AutoCommit)
               DbContext.SaveChanges();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void Delete(int id)
      {
         var entity = GetById(id);
         if (entity == null) return;
         Delete(entity);
      }

      public void Edit(int idTask)
      {

      }

      public IQueryable<TModel> GetAll()
      {
         return DbSet;
      }

      private TModel GetById(object id)
      {
         return DbSet.Find(id);
      }
   }
}
