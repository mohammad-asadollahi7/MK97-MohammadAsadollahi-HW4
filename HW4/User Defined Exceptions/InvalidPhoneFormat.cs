using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.User_Defined_Exceptions
{
    internal class InvalidPhoneFormat : Exception
    {
        public InvalidPhoneFormat(string message) 
                    : base (message)
        { }
    }
}
