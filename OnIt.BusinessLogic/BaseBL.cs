using OnIt.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.BusinessLogic
{
   public class BaseBL
   {
      internal OnItDbContext context;
      internal string connectionString;

      public BaseBL(string connectionString)
      {
         this.connectionString = connectionString;
         context = new OnItDbContext(connectionString);
      }
   }
}
