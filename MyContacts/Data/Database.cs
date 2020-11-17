using System;
using System.Data.SQLite;
using MyContacts.Interfaces;

namespace MyContacts.Data
{
	public class Database : Singleton
	{
		private SQLiteConnection _sqLiteConnection;
		private SQLiteCommand _sqLiteCommand;
		private SQLiteDataReader _dataReader;

		private Database()
		{
			_sqLiteConnection = new SQLiteConnection("Data Source=Database.db;Version=3;Compress=True");
			_sqLiteConnection.Open();

			_sqLiteCommand = _sqLiteConnection.CreateCommand();
		}

		public void ExecSql()
		{
		}

		public SQLiteDataReader RawQuery()
		{
			throw new NotImplementedException();
		}
	}
}