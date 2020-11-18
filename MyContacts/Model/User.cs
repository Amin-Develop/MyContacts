using System.Collections.Generic;

namespace MyContacts.Model
{
    public class User
    {
        // also add properties you need for your user model

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}