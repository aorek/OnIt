using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.Helper
{
   public static class ReflectionExtension
   {
      public static T CloneObject<T>(this object o) where T : new()
      {
         T aux = new T();
         if (o != null)
         {
            var properties = o.GetType().GetProperties();

            foreach (var prop in properties)
            {
               var value = prop.GetValue(o);
               prop.SetValue(aux, value);
            }
         }
         return aux;
      }
   }
}
