using System.Data.SQLite;

namespace MyContacts.Data
{
	internal class Database
	{
		private Database _this;

		private SQLiteConnection _sqLiteConnection;
		private SQLiteCommand _sqLiteCommand;
		private SQLiteDataReader _dataReader;

		private Database()
		{
			_sqLiteConnection = new SQLiteConnection("Data Source=Database.db;Version=3;Compress=True");
			_sqLiteConnection.Open();

			_sqLiteCommand = _sqLiteConnection.CreateCommand();
		}

		internal Database GetInstance() => _this ??= new Database();

		internal void ExecSql()
		{
			
		}

		internal void RawQuery()
		{
			
		}
	}
}