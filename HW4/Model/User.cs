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

        public string Mobile { get; set; }

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
