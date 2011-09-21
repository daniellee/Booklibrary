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

	    [Test]
	    public void Get_ABookThatExists_ShouldReturnThatBook()
	    {
            book = new Book { Title = "My Lovely Horse runnning in the field" };
            booksRepository.Save(book);

	        Book result = booksRepository.Get(book.Id);

            Assert.That(result.Id, Is.EqualTo(book.Id));
	    }

	    [Test]
	    public void Delete_ExistingBook_ShouldDelete()
	    {
	        book = new Book {Title = "My Lovely Horse"};
            booksRepository.Save(book);

            booksRepository.Delete(book.Id);

            Assert.That(booksRepository.Get(book.Id), Is.Null);

	        CleanupAfterDelete();
	    }

	    private void CleanupAfterDelete()
	    {
	        book = null;
	    }

	    [TearDown]
		public void AfterEachTest()
		{
			if(book != null)
				booksRepository.Delete(book);
		}
	}
}
