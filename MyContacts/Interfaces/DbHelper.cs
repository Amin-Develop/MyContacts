using MyContacts.Data;
using MyContacts.Model;

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
    }
}