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

		public ViewResult Create(CreateBook createBook)
		{
			booksRepository.Save(new Book{ Title = createBook.Title });
			return null;
		}

		[HttpGet]
		public ViewResult Create()
		{
			return View("");
		}
	}
}