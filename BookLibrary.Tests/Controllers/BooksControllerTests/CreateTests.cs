using System;
using System.Reflection;
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
			var result = homeController.Create();

			Assert.That(result.ViewName, Is.EqualTo(""));
		}

		[Test]
		public void ParameterLessCreate_Should_Respond_To_HttpGet()
		{
			var attributes = homeController.GetType().GetMethod("Create", new Type[0]).GetCustomAttributes(false);

			Assert.That(attributes[0], Is.TypeOf<HttpGetAttribute>());
		}

		[Test]
		public void Valid_ViewModel_Should_Be_Saved()
		{
			homeController.Create(new CreateBook { Title = "sometitle"});

			booksRepositoryMock.Verify(b => b.Save(It.Is<Book>(bo => bo.Title == "sometitle")));
		}
	}
}