using MyContacts.Interfaces;
using System.Data.SQLite;

namespace MyContacts.Data
{
	public class Database
	{
		private static Database _this;

		private SQLiteConnection _sqLiteConnection;
		private SQLiteCommand _sqLiteCommand;
		private SQLiteDataReader _dataReader;

		private Database()
		{
			_sqLiteConnection = new SQLiteConnection("Data Source=Database.db;Version=3;Compress=True");
			_sqLiteConnection.Open();

			_sqLiteCommand = _sqLiteConnection.CreateCommand();
		}

		public static Database GetInstance() => _this ??= new Database();

		public void ExecSql(string sql)
		{
			if (_dataReader != null && !_dataReader.IsClosed) _dataReader.Close();

			_sqLiteCommand.CommandText = sql;
			_sqLiteCommand.ExecuteNonQuery();
		}

		public SQLiteDataReader RawQuery(string query)
		{
			if (_dataReader != null && !_dataReader.IsClosed) _dataReader.Close();

			_sqLiteCommand.CommandText = query;
			_dataReader = _sqLiteCommand.ExecuteReader();

			return _dataReader;
		}
	}
}