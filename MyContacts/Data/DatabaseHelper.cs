using MyContacts.Interfaces;
using MyContacts.Model;
using System.Collections.Generic;

namespace MyContacts.Data
{
	public class DatabaseHelper : DbHelper
	{
		private static DatabaseHelper _this;

		// commands
		private const string CheckUserTable = "SELECT name FROM sqlite_master WHERE type='table' AND name='users'";
		private const string CheckContactTable = "SELECT name FROM sqlite_master WHERE type='table' AND name='contacts'";

		// ------------------------------------------------------------------------------------------------------------------------ \\

		private const string CreateUserTable =
			"CREATE TABLE users (id INTEGER PRIMARY KEY AUTOINCREMENT, username VARCHAR(50), pass VARCHAR(50))";

		private const string CreateContactTable =
			"CREATE TABLE contacts (id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER, full_name VARCHAR(100), ip VARCHAR(30), age TINYINT(2))";

		// ------------------------------------------------------------------------------------------------------------------------ \\

		private const string InsertContactRow = "INSERT INTO contacts (user_id, full_name, ip, age) VALUES ({0}, '{1}', '{2}', {3})";
		private const string InsertUserRow = "INSERT INTO users (username, pass) VALUES ('{0}', '{1}')";

		// ------------------------------------------------------------------------------------------------------------------------ \\

		private const string CheckExistingContactName = "SELECT id FROM contacts WHERE full_name='{0}'";
		private const string CheckExistingContactIp = "SELECT id FROM contacts WHERE ip='{0}'";
		private const string CheckUserExist = "SELECT id FROM users WHERE username='{0}'";
		private const string GetUserPass = "SELECT pass FROM users WHERE username='{0}'";
		private const string GetUserContacts = "SELECT * FROM contacts WHERE user_id={0}";
		private const string GetUserByUsernamePass = "SELECT * FROM users WHERE username='{0}' AND pass='{1}'";

		private DatabaseHelper()
		{
			if (!_database.RawQuery(CheckUserTable).HasRows) _database.ExecSql(CreateUserTable);
			if (!_database.RawQuery(CheckContactTable).HasRows) _database.ExecSql(CreateContactTable);
		}

		public static DatabaseHelper GetInstance()
		{
			return _this ??= new DatabaseHelper();
		}

		public override void InsertContact(Contact contact)
		{
			var formattedStr = string.Format(InsertContactRow, contact.User.Id, contact.FullName, contact.Ip, contact.Age);
			_database.ExecSql(formattedStr);

			contact.User.Contacts = GetContactsByUser(contact.User);
		}

		public override void Register(User user)
		{
			var formattedString = string.Format(InsertUserRow, user.UserName, user.Password);
			_database.ExecSql(formattedString);
		}

		public override List<Contact> GetContactsByUser(User user)
		{
			var formattedStr = string.Format(GetUserContacts, user.Id);
			var query = _database.RawQuery(formattedStr);

			var contacts = new List<Contact>();

			if (!query.HasRows) return contacts;

			while (query.Read())
			{
				var contact = new Contact
				{
					Id = query.GetInt32(0),
					User = user,
					FullName = query.GetString(2),
					Ip = query.GetString(3),
					Age = query.GetInt32(4)
				};
				contacts.Add(contact);
			}

			return contacts;
		}

		public override User GetCurrentUser(string username, string password)
		{
			var formattedStr = string.Format(GetUserByUsernamePass, username, password);
			var query = _database.RawQuery(formattedStr);

			var user = new User();

			if (!query.HasRows) return user;

			query.Read();
			user.Id = query.GetInt32(0);
			user.UserName = query.GetString(1);
			user.Password = query.GetString(2);

			user.Contacts = GetContactsByUser(user);

			return user;
		}

		public bool ContactNameExist(string name)
		{
			var formattedStr = string.Format(CheckExistingContactName, name);
			return _database.RawQuery(formattedStr).HasRows;
		}

		public bool ContactIpExist(string ip)
		{
			var formattedStr = string.Format(CheckExistingContactIp, ip);
			return _database.RawQuery(formattedStr).HasRows;
		}

		public bool UserExist(string username)
		{
			var formattedStr = string.Format(CheckUserExist, username);
			return _database.RawQuery(formattedStr).HasRows;
		}

		public string GetUserPassword(string username)
		{
			var formattedStr = string.Format(GetUserPass, username);
			var dataReader = _database.RawQuery(formattedStr);
			dataReader.Read();
			return dataReader.GetString(0);
		}
	}
}