using System;
using System.Web.Mvc;
using BookLibrary.Domain.Entities;
using BookLibrary.ViewModels;
using Moq;
using NUnit.Framework;

namespace BookLibrary.Tests.Controllers.BooksControllerTests
{
	[TestFixture]
	public class CreateTests : TestsBase
	{
		[Test]
		public void ParameterLessCreate_Should_Return_CreateView()
		{
			var result = booksController.Create();

			Assert.That(result.ViewName, Is.EqualTo(""));
		}

		[Test]
		public void ParameterLessCreate_Should_Respond_To_HttpGet()
		{
			var attributes = booksController.GetType().GetMethod("Create", new Type[0]).GetCustomAttributes(false);

			Assert.That(attributes[0], Is.TypeOf<HttpGetAttribute>());
		}

		[Test]
		public void Valid_ViewModel_Should_Be_Saved()
		{
			booksController.Create(new CreateBook { Title = "sometitle"});

			booksRepositoryMock.Verify(b => b.Save(It.Is<Book>(bo => bo.Title == "sometitle")));
		}

		[Test]
		public void When_Invalid_ViewModel_Do_Not_Save()
		{
			booksController.ModelState.AddModelError("fel", "fel");
			booksController.Create(new CreateBook ());

			booksRepositoryMock.Verify(b => b.Save(It.IsAny<Book>()), Times.Never());
		}

		[Test]
		public void When_Invalid_ViewModel_Return_Model_To_View()
		{
			booksController.ModelState.AddModelError("fel", "fel");
			var createBook = new CreateBook();
			var result = (ViewResult)booksController.Create(createBook);

			Assert.That(result.Model, Is.SameAs(createBook));
		}


		[Test]
		public void When_Saved_Should_Redirect_To_Index()
		{
			var result = (RedirectToRouteResult)booksController.Create(new CreateBook { Title = "sometitle" });

			Assert.That(result.RouteValues["controller"], Is.Null);
			Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
		}
	}
}