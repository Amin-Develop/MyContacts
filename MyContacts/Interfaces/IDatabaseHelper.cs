namespace MyContacts.Interfaces
{
	public interface IDatabaseHelper
	{
		// gives you instance of the database helper (singleton)
		public IDatabaseHelper GetInstance();
		
		// put your methods here
		// GetUser()
		// SaveUser()
		// ...
	}
}