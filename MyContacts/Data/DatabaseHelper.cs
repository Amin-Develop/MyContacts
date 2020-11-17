using MyContacts.Interfaces;

namespace MyContacts.Data
{
	public class DatabaseHelper : DbHelper
	{
		private DatabaseHelper()
		{
		}

        public override void InsertContact(string name, string ip, int Age)
        {
            throw new System.NotImplementedException();
        }

        public override void Register()
        {
            throw new System.NotImplementedException();
        }
    }
}