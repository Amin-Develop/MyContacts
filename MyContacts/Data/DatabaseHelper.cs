using MyContacts.Interfaces;
using MyContacts.Model;

namespace MyContacts.Data
{
	public class DatabaseHelper : DbHelper
	{
		// commands
		private const string CheckUserTable = "SELECT * FROM sqlite_master WHERE type='table' AND name='users'";
		private const string CheckContactTable = "SELECT * FROM sqlite_master WHERE type='table' AND name='contacts'";

		private const string CreateUserTable =
			"CREATE TABLE users (id INTEGER PRIMARY KEY AUTOINCREMENT, username VARCHAR(50), pass VARCHAR(50))";

		private const string CreateContactTable =
			"CREATE TABLE contacts (id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER, full_name VARCHAR(100), ip VARCHAR(30), age TINYINT(2))";

		private const string InsertContactRow = "INSERT INTO contacts (user_id, full_name, ip, age) VALUES ({0}, '{1}', '{2}', {3})";
		private const string InsertUserRow = "INSERT INTO users (username, pass) VALUES ('{0}', '{1}')";

		private DatabaseHelper()
		{
			if (!_database.RawQuery(CheckUserTable).HasRows) _database.ExecSql(CreateUserTable);
			if (!_database.RawQuery(CheckContactTable).HasRows) _database.ExecSql(CreateContactTable);
		}

		public override void InsertContact(Contact contact)
		{
			var formattedStr = string.Format(InsertContactRow, contact.User.Id, contact.FullName, contact.Ip, contact.Age);
			_database.ExecSql(formattedStr);
		}

		public override void Register(User user)
		{
			var formattedString = string.Format(InsertUserRow, user.UserName, user.Password);
			_database.ExecSql(formattedString);
		}
	}
}