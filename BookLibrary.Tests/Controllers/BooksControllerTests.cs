using System.Collections.Generic;
using BookLibrary.Controllers;
using BookLibrary.Domain;
using BookLibrary.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace BookLibrary.Tests.Controllers
{
	[TestFixture]
	public class BooksControllerTests
	{
		private BooksController homeController;
		private Mock<IBookRepository> booksRepositoryMock;

		[SetUp]
		public void Setup()
		{
			booksRepositoryMock = new Mock<IBookRepository>();
			booksRepositoryMock.Setup(b => b.List()).Returns(new List<Book>());
			homeController = new BooksController(booksRepositoryMock.Object);
		}

		[Test]
		public void Index_ShouldReturnIndexView()
		{
			var result = homeController.Index();

			Assert.That(result.ViewName, Is.EqualTo(""));
		}

		[Test]
		public void Index_ShouldPassBooksToView()
		{
			var books = new List<Book>();
			booksRepositoryMock.Setup(b => b.List()).Returns(books);

			var result = homeController.Index();

			Assert.That(result.Model, Is.SameAs(books));
			
		}
	}
}
