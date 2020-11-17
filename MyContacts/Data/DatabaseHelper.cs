using MyContacts.Interfaces;

namespace MyContacts.Data
{
	public class DatabaseHelper : IDatabaseHelper
	{
		private DatabaseHelper _this;
		
		private DatabaseHelper() {}
		
		public IDatabaseHelper GetInstance()
		{
			return _this ??= new DatabaseHelper();
		}
	}
}