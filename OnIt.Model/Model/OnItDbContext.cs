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

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Entity<TaskModel>()
                     .Property(f => f.CreationDate)
                     .HasColumnType("datetime2")
                     .HasPrecision(0);

         modelBuilder.Entity<TaskModel>()
                    .Property(f => f.DueDate)
                    .HasColumnType("datetime2")
                    .HasPrecision(0);
      }
   }
}
