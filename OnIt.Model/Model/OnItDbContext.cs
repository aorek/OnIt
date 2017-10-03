using OnIt.Helper;
using System.Collections.Generic;
using System.Data.Entity;

namespace OnIt.Model
{
   public class OnItDbContext : DbContext
   {
      public OnItDbContext() : base(ConnectionStringSingleton.Instance.ConnectionString)
      {
      }

      public OnItDbContext(string connectionString) : base(connectionString)
      {
      }

      public virtual DbSet<TaskModel> TASK { get; set; }      
   }
}
