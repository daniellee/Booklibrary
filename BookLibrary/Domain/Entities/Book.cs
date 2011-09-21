namespace BookLibrary.Domain.Entities
{
	public class Book : IBook
	{
		public string Id { get; set; }
		public string Title { get; set; }
	}
}