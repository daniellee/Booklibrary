using System.Web.Mvc;

namespace BookLibrary.UI.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index()
		{
			return View();
		}
	}
}