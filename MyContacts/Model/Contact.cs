namespace MyContacts.Model
{
	public class Contact
	{
		public int Id { get; set; }

		public string FullName { get; set; }

		public string Ip { get; set; }

		public int Age { get; set; }

		public User User { get; set; }
	}
}