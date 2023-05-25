using HW4.User_Defined_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        private string _mobile;
        public string Mobile
        {
            get
            {
                return _mobile;
            }

            set
            {
                if (value.Length == 11)
                {
                    _mobile = value;
                }
                else
                {
                    throw new InvalidPhoneFormat("Phone is not valid.");
                }
            }
        }

        private DateTime _birthday;
        public DateTime BirthDay
        {
            get
            {
                return _birthday;
            }

            set
            {
                if (value < DateTime.Today)
                {
                    _birthday = value;
                }
                else
                {
                    throw new InvaildBirthDay("The input birthday is not valid. ");
                }

            }

        }
    }
}
