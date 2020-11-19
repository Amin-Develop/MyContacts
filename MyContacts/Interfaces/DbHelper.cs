using MyContacts.Data;
using MyContacts.Model;
using System.Collections.Generic;

namespace MyContacts.Interfaces
{
    public abstract class DbHelper
    {
        protected Database _database;

        protected DbHelper()
        {
            _database = Database.GetInstance();
        }

        //if all thing was valid the Login form must Show() after the user inserted
        public abstract void Register(User user);

        //if all things were valid the Contacts form must Show() after the contact inserted
        public abstract void InsertContact(Contact contact);

        //return the contacts of the user
        public abstract List<Contact> GetContactsByUser(User user);

        //find user in db by username and password 
        public abstract User GetCurrentUser(string username,string password);

        //return all users wich their fullnames contains the 'containname' parameter
        public abstract List<Contact> GetContactByFullName(User user, string containname);
    }
}