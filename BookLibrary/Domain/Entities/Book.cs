namespace BookLibrary.Domain.Entities
{
	public class Book : IBook
	{
		public int Id { get; set; }
		public string Title { get; set; }
	}
}