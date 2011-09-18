using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookLibrary.Domain.Entities;
using BookLibrary.Persistence;
using NUnit.Framework;
using Raven.Client.Document;

namespace BookLibrary.IntegrationTests
{
	public class RepositoryTestsBase
	{
		protected DocumentStore documentStore;

		[TestFixtureSetUp]
		public void SetupAllTests()
		{
			documentStore = new DocumentStore { Url = "http://localhost:8080" };
			documentStore.Initialize();
		}

		[TestFixtureTearDown]
		public void TearDownAllTests()
		{
			documentStore.Dispose();
		}
	}

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
			booksRepository.Add(book);

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
