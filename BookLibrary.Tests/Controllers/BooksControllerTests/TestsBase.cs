using System.Collections.Generic;
using BookLibrary.Controllers;
using BookLibrary.Domain;
using BookLibrary.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace BookLibrary.Tests.Controllers.BooksControllerTests
{
	public class TestsBase
	{
		protected BooksController homeController;
		protected Mock<IBooksRepository> booksRepositoryMock;

		[SetUp]
		public virtual void Setup()
		{
			booksRepositoryMock = new Mock<IBooksRepository>();
			booksRepositoryMock.Setup(b => b.List()).Returns(new List<Book>());
			homeController = new BooksController(booksRepositoryMock.Object);
		}
	}
}