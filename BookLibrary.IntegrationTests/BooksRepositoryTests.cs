using System.Linq;
using BookLibrary.Domain.Entities;
using BookLibrary.Persistence;
using NUnit.Framework;

namespace BookLibrary.IntegrationTests
{
	[TestFixture]
	public class BooksRepositoryTests : RepositoryTestsBase
	{
		private BooksRepository booksRepository;
		private Book book;

		[SetUp]
		public void Setup()
		{
			booksRepository = new BooksRepository(documentStore);
		}

		[Test]
		public void Add_BookWithTitle_ShouldPersist()
		{
			book = new Book {Title = "jippi"};
			booksRepository.Save(book);

			var books = booksRepository.List();

			Assert.That(books.First().Title, Is.EqualTo("jippi"));
			
		}

		[TearDown]
		public void AfterEachTest()
		{
			if(book != null)
				booksRepository.Delete(book);
		}
	}
}
