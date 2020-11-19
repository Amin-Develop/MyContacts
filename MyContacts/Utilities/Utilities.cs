using System.Collections.Generic;
using MyContacts.Model;

namespace MyContacts.Utilities
{
    public static class Utilities
    {
        public static List<Contact> FilterByFullName(string fullname,List<Contact> contacts)
        {
            var filteredList = contacts.FindAll(contact => contact.FullName.Contains(fullname));
            return filteredList;
        }
    }
}
