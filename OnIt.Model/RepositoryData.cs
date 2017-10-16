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

      public IQueryable<TModel> GetData(/*string orderBy, string filter, params object[] paremetersFilter*/)
      {
         return DbSet;
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
   }
}
