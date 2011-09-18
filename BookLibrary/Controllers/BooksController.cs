using System.Web.Mvc;
using BookLibrary.Domain;

namespace BookLibrary.Controllers
{
	public class BooksController : Controller
	{
		private readonly IBooksRepository booksRepository;

		public BooksController(IBooksRepository booksRepository)
		{
			this.booksRepository = booksRepository;
		}

		public ViewResult Index()
		{
			return View(booksRepository.List());
		}
	}
}