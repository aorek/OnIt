using System.Collections.Generic;
using System.Data.Entity;

namespace OnIt.Model
{
   public static class ConnectionString
   {
      public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnIt.Model.OnItContext;Integrated Security=true";
   }

   public class OnItDbContext : DbContext
   {
      public OnItDbContext() : base(ConnectionString.connectionString)
      {
      }

      public OnItDbContext(string connectionString) : base(connectionString)
      {
      }

      public virtual DbSet<TaskModel> TASK { get; set; }      
   }
}
