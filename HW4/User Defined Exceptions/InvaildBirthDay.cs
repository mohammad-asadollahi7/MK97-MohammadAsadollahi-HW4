using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.User_Defined_Exceptions
{
    public class InvaildBirthDay : Exception
    {
        public InvaildBirthDay(string message)
            : base (message)
        {
            
        }
    }
}
