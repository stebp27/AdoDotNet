using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdoExamPattern
{
    class UserInterface
    {
        private DataProcessor processor;
        const string MENU_MESSAGE = "Welcome. Please press:\n" +
            "'a' + enter to display all authors\n" +
            "'b' + enter to display all books\n" +
            "'n' + enter to insert a new book\n" +
            "'v' + enter to see the average book's price\n" +
            "'m' + enter to see the mode book's price\n" +
            "'q' + enter to quit";

        public UserInterface(DataProcessor processor)
        {
            this.processor = processor;
        }

        public void MainMenu()
        {
            Console.WriteLine(MENU_MESSAGE);
            string input = ReadAnswer();

            switch (input[0])
            {
                case 'a':
                    ShowAuthors();
                    break;
                case 'b':
                    ShowBooks();
                    break;
                case 'n':
                    InsertBook();
                    break;
                case 'v':
                    ShowAverage();
                    break;
                case 'm':
                    ShowMode();
                    break;
                case 'q':
                    return;
                default:
                    Console.WriteLine("Not valid input, please try again");
                    break;
            }
            MainMenu();
        }

        public Author FindAuthorById(int id)
        {
            return processor.FindAuthorById(id);
        }

        private void InsertBook()
        {
            Console.WriteLine("Please enter the new book's title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter the new book's publication's date: ");
            DateTime publicationDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the new book's category: ");
            string category = Console.ReadLine();
            Console.WriteLine("Please enter the new book's pages: ");
            int pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the new book's price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the new book's publishing house name: ");
            string publishingHouse = Console.ReadLine();
            Console.WriteLine("Please enter the new book's author's id or press 'l' + enter to se author's list: ");
            string input = Console.ReadLine();
            if (input == "l")
            {
                ShowAuthors();
                Console.WriteLine("Please enter the new book's author's id: ");
                input = Console.ReadLine();
            }
            int authorId = int.Parse(input);
            Author author = FindAuthorById(authorId);
            Book book = processor.InsertBook(new Book(publicationDate, category, title, pages, price, publishingHouse, authorId, author));
            Console.WriteLine(book.ToString());
        }

        private void ShowBooks()
        {
            IEnumerable<Book> books = processor.GetBooks();
            if (books.Any())
            {
                foreach (var book in books)
                {
                    Console.WriteLine(book.ToString());
                }
            }
            else
            {
                Console.WriteLine("There are no books.");
            }
        }

        private void ShowAuthors()
        {
            IEnumerable<Author> authors = processor.GetAuthors();
            if (authors.Any())
            {
                foreach (var author in authors)
                {
                    Console.WriteLine(author.ToString());
                }
            }
            else
            {
                Console.WriteLine("There are no authors.");
            }
        }

        private void ShowAverage()
        {
            Console.WriteLine($"Average price is: {processor.AveragePrice()}");
        }

        private void ShowMode()
        {
            Console.WriteLine($"Mode price is: {processor.ModePrice()}");
        }

        private string ReadAnswer(string prompt = "")
        {
            Console.Write(prompt);
            return Console.ReadLine().ToLower();
        }
    }
}
