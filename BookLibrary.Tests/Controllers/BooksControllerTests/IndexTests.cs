using System.Collections.Generic;
using BookLibrary.Domain.Entities;
using NUnit.Framework;

namespace BookLibrary.Tests.Controllers.BooksControllerTests
{
	[TestFixture]
	public class IndexTests : TestsBase
	{
		[SetUp]
		public override void Setup()
		{
			base.Setup();
			booksRepositoryMock.Setup(b => b.List()).Returns(new List<Book>());
		}

		[Test]
		public void Should_Return_Index_View()
		{
			var result = homeController.Index();

			Assert.That(result.ViewName, Is.EqualTo(""));
		}

		[Test]
		public void Should_Pass_Books_To_View()
		{
			var books = new List<Book>();
			booksRepositoryMock.Setup(b => b.List()).Returns(books);

			var result = homeController.Index();

			Assert.That(result.Model, Is.SameAs(books));
		}
	}
}
