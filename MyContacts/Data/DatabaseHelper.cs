using MyContacts.Interfaces;
using MyContacts.Model;

namespace MyContacts.Data
{
	public class DatabaseHelper : DbHelper
	{
		private DatabaseHelper()
		{
		}

        public override void InsertContact(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public override void Register(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}