using System.Collections.Generic;
using MyContacts.Interfaces;
using MyContacts.Model;

namespace MyContacts.Data
{
	public class DatabaseHelper : DbHelper
	{
		private const string CheckUsersTable = "SELECT * FROM sqlite_master WHERE type='table' AND name='users'";
		private const string CheckContactsTable = "SELECT * FROM sqlite_master WHERE type='table' AND name='contacts'";

		private DatabaseHelper()
		{
		}

		public override void Register(User user)
		{
			throw new System.NotImplementedException();
		}

		public override void InsertContact(User user)
		{
			throw new System.NotImplementedException();
		}

		public override List<User> GetContactsList()
		{
			throw new System.NotImplementedException();
		}
	}
}