using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdoExamPattern
{
    class DataProcessor
    {
        private DataSource source;

        public DataProcessor(DataSource dataSource)
        {
            source = dataSource;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return source.GetAuthors();
        }

        public IEnumerable<Book> GetBooks()
        {
            return source.GetBooks();
        }

        public Book InsertBook(Book book)
        {
            return source.InsertBook(book);
        }

        public Author FindAuthorById(int authorId)
        {
            return source.GetAuthors().SingleOrDefault(a => a.Id == authorId);
        }

        public decimal AveragePrice()
        {
            return source.GetBooks().Average(b => b.Price);
        }

        public decimal ModePrice()
        {
            return CalculateMode(source.GetBooks());
        }

        public decimal CalculateMode(IEnumerable<Book> books)
        {
            return books
                .GroupBy(b => b.Price)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }

    }
}
