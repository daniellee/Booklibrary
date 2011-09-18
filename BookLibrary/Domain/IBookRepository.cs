using System.Collections.Generic;
using BookLibrary.Domain.Entities;

namespace BookLibrary.Domain
{
	public interface IBookRepository
	{
		IEnumerable<Book> List();
	}
}