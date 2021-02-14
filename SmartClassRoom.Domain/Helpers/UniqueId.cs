using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClassRoom.Domain.Helpers
{
   public class UniqueId
    {
        public static string UniqueKey = Guid.NewGuid().ToString();
    }
}
