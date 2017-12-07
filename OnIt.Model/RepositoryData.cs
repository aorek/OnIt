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

      public bool Create(TModel entity)
      {
         try
         {
            DbSet.Add(entity);

            if (AutoCommit)
               DbContext.SaveChanges();

            return true;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public bool Delete(TModel entity)
      {
         try
         {
            DbSet.Attach(entity);
            DbSet.Remove(entity);

            if (AutoCommit)
               DbContext.SaveChanges();

            return true;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public bool Delete(int id)
      {
         var entity = GetById(id);
         if (entity == null) return false;
         return Delete(entity);
      }

      public IQueryable<TModel> GetAll()
      {
         return DbSet;
      }

      public TModel GetById(object id)
      {
         return DbSet.Find(id);
      }

      public bool Update(TModel entity, TModel modifiedEntity)
      {
         var dbEntityEntry = DbContext.Entry(entity);
         try
         {
            dbEntityEntry.CurrentValues.SetValues(modifiedEntity);
            dbEntityEntry.State = EntityState.Modified;

            if (AutoCommit)
               DbContext.SaveChanges();

            return true;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }
}
