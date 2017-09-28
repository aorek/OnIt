using System.Collections.Generic;
using System.Data.Entity;

namespace OnIt.Model
{
   public class OnItContext : DbContext
   {
      public DbSet Task { get; set; }
   }
}
