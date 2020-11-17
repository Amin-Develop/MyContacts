using MyContacts.Data;

namespace MyContacts.Interfaces
{
	public abstract class DbHelper : Singleton
	{
		protected Database _database;

		protected DbHelper()
		{
			_database = (Database) GetInstance();
		}

		// put your methods here (must be public abstract)
		// GetUser()
		// SaveUser(User user)
		// ...
	}
}