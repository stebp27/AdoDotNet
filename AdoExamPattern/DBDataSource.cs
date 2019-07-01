using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoExamPattern
{
    class DBDataSource : DataSource
    {
        private const string CONNECTION_STRING =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdoExamPattern;Integrated Security=True;";

        private const string ALL_AUTHORS_QUERY =
            "SELECT Id, FirstName, LastName, BirthDate, Email FROM dbo.Authors";

        private const string ALL_BOOKS_QUERY =
            "SELECT Id, PublicationDate, Category, Title, Pages, Price, PublishingHouse, AuthorId " +
            "FROM dbo.Books";

        private const string INSERT_BOOK_QUERY =
            "INSERT INTO dbo.Books (PublicationDate, Category, Title, Pages, Price, PublishingHouse, AuthorId)" +
            "output INSERTED.Id values (@PublicationDate, @Category, @Title, @Pages, @Price, @PublishingHouse, @AuthorId)";

        public IEnumerable<Author> GetAuthors()
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(ALL_AUTHORS_QUERY, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    var posId = reader.GetOrdinal("Id");
                    var posFirstName = reader.GetOrdinal("FirstName");
                    var posLastName = reader.GetOrdinal("LastName");
                    var posBirthDate = reader.GetOrdinal("BirthDate");
                    var posEmail = reader.GetOrdinal("Email");

                    var authors = new List<Author>();
                    while(reader.Read())
                    {
                        var author = new Author(reader.GetInt32(posId), reader.GetString(posFirstName),
                            reader.GetString(posLastName), reader.GetDateTime(posBirthDate), reader.GetString(posEmail));

                        authors.Add(author);
                    }
                    return authors;
                }
            }
        }
        
        public IEnumerable<Book> GetBooks()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(ALL_BOOKS_QUERY, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    var posId = reader.GetOrdinal("Id");
                    var posPublicationDate = reader.GetOrdinal("PublicationDate");
                    var posCategory = reader.GetOrdinal("Category");
                    var posTitle = reader.GetOrdinal("Title");
                    var posPages = reader.GetOrdinal("Pages");
                    var posPrice = reader.GetOrdinal("Price");
                    var posPublishingHouse = reader.GetOrdinal("PublishingHouse");
                    var posAuthorId = reader.GetOrdinal("AuthorId");

                    var books = new List<Book>();
                    while (reader.Read())
                    {
                        var book = new Book(reader.GetInt32(posId), reader.GetDateTime(posPublicationDate),
                            reader.GetString(posCategory), reader.GetString(posTitle), reader.GetInt32(posPages),
                            reader.GetDecimal(posPrice), reader.GetString(posPublishingHouse), reader.GetInt32(posAuthorId));
                        books.Add(book);
                    }
                    return books;
                }
            }
        }

        public Book InsertBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(INSERT_BOOK_QUERY, connection))
                {
                    command.Parameters.AddWithValue("@PublicationDate", book.PublicationDate);
                    command.Parameters.AddWithValue("@Category", book.Category);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Pages", book.Pages);
                    command.Parameters.AddWithValue("@Price", book.Price);
                    command.Parameters.AddWithValue("@PublishingHouse", book.PublishingHouse);
                    command.Parameters.AddWithValue("@AuthorId", book.AuthorId);

                    int id = (int)command.ExecuteScalar();
                    book.Id = id;
                    return book;
                }
            }
        }
    }
}
