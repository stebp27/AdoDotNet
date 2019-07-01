using System;
using System.Collections.Generic;
using System.Text;

namespace AdoExamPattern
{
    public interface DataSource
    {
        IEnumerable<Book> GetBooks();
        IEnumerable<Author> GetAuthors();
        Book InsertBook(Book book);
    }
}
