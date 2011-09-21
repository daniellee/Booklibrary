using System.Web.Mvc;
using BookLibrary.Domain;
using BookLibrary.Domain.Entities;
using BookLibrary.ViewModels;

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

		public ActionResult Create(CreateBook createBook)
		{
			if(!ModelState.IsValid)
			{
				return View(createBook);
			}

			booksRepository.Save(new Book{ Title = createBook.Title });
			
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ViewResult Create()
		{
			return View("");
		}
	}
}