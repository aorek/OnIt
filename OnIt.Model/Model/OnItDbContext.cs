using System.Collections.Generic;
using System.Data.Entity;

namespace OnIt.Model
{
   public class OnItDbContext : DbContext
   {
      public virtual DbSet<TaskModel> TASK { get; set; }

      public OnItDbContext(string connectionString) : base(connectionString)
      {
      }
   }
}
