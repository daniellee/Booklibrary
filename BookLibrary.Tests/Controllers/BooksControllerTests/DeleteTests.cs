using System.Diagnostics;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;

namespace BookLibrary.Tests.Controllers.BooksControllerTests
{
    [TestFixture]
    public class DeleteTests : TestsBase
    {
        [Test]
        public void AnExistingBook_ShouldDelete()
        {
            const int bookId = 1;
            
            booksController.Delete(bookId);
   
            booksRepositoryMock.Verify(r => r.Delete(bookId));
        }

        [Test]
        public void WhenDeleted_ShouldRedirectToIndex()
        {
            var result = (RedirectToRouteResult)booksController.Delete(1);

            Assert.That(result.RouteValues["controller"], Is.Null);
            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }
    }
}