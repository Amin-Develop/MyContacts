namespace MyContacts.Interfaces
{
	public class Singleton
	{
		private static Singleton _this;

		public static Singleton GetInstance()
		{
			return _this ??= new Singleton();
		}
	}
}