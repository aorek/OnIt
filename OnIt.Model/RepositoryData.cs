using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.Model.Repository
{
   public class RepositoryData<T> where T : class
   {
      public DbContext Context { get; set; }

      public RepositoryData()
      {

      }
   }
}
