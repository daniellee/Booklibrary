using BookLibrary.UI.Controllers;
using NUnit.Framework;

namespace BookLibrary.Tests.UI.Controllers
{
	[TestFixture]
	public class HomeControllerTests
	{
		private HomeController homeController;

		[SetUp]
		public void Setup()
		{
			homeController = new HomeController();
		}

		[Test]
		public void Should_Have_Index_View()
		{
			var result = homeController.Index();

			Assert.That(result.ViewName, Is.EqualTo(""));
		}
	}
}
