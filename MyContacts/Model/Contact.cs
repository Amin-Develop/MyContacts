using System;
using System.Collections.Generic;
using System.Text;

namespace MyContacts.Model
{
    public class Contact
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Ip { get; set; }

        public int Age { get; set; }

        public virtual User User { get; set; }

        public Contact()
        {

        }
    }
}
