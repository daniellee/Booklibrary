using System.Linq;
using System.Web.Mvc;
using BookLibrary.Domain;

namespace BookLibrary.Controllers
{
	public class BooksController : Controller
	{
		private readonly IBookRepository bookRepository;

		public BooksController(IBookRepository bookRepository)
		{
			this.bookRepository = bookRepository;
		}

		public ViewResult Index()
		{
			return View(bookRepository.List().ToList());
		}
	}
}