using System.Collections.Generic;
using BookLibrary.Domain.Entities;

namespace BookLibrary.Domain
{
	public interface IBooksRepository
	{
		IEnumerable<Book> List();
	}
}