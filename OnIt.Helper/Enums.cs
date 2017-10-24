using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnIt.Helper
{
   public static class Enums
   {
      public enum PriorityTypes {
         Low,
         Medium,
         High,
         Very_high
      }

      public enum MessageTypes
      {
         Success,
         Information,
         Error,
         Warning
      }
   }
}
