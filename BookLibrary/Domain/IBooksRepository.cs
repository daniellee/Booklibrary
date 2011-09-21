using System.Collections.Generic;
using BookLibrary.Domain.Entities;

namespace BookLibrary.Domain
{
	public interface IBooksRepository
	{
		IEnumerable<IBook> List();
		void Save(Book book);
	    void Delete(int bookId);
	}
}