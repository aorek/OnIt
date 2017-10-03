using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.Helper
{
   public class ConnectionStringSingleton
   {
      private static ConnectionStringSingleton instance;

      public string ConnectionString { get; set; }

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
