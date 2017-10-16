using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.Helper
{
   public class ConnectionStringSingleton
   {
      public string ConnectionString { get; set; }

      private static ConnectionStringSingleton instance;
      public static ConnectionStringSingleton Instance
      {
         get
         {
            if (instance == null)
               instance = new ConnectionStringSingleton();
            return instance;
         }
      }

      public ConnectionStringSingleton()
      {
         ConnectionString = "name=OnitDbContext";
      }
   }
}
