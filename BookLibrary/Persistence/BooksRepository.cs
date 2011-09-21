using System.Collections.Generic;
using System.Linq;
using BookLibrary.Domain;
using BookLibrary.Domain.Entities;
using Raven.Client;
using Raven.Client.Document;

namespace BookLibrary.Persistence
{
	public class BooksRepository : IBooksRepository
	{
		private readonly DocumentStore store;
		private readonly IDocumentSession session;

		public BooksRepository(DocumentStore store)
		{
			this.store = store;
			this.session = store.OpenSession();
		}

		public IEnumerable<IBook> List()
		{
			return session.Query<Book>().ToList();
		}

		public void Save(Book book)
		{
			session.Store(book);
			session.SaveChanges();
		}

	    public void Delete(int bookId)
	    {
            Book book = Get(bookId);
            Delete(book);
	    }

	    public void Delete(Book book)
		{
			session.Delete(book);
			session.SaveChanges();
		}

	    public Book Get(int id)
	    {
	        return session.Load<Book>("books/" + id);
	    }
	}
}