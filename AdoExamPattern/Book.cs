using System;
using System.Collections.Generic;
using System.Text;

namespace AdoExamPattern
{
    public class Book
    {
        public int Id { get; set; }
        public DateTime PublicationDate { get; set; }
        //It may better be an enum
        public string Category { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public string PublishingHouse { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public Book() { }

        public Book(DateTime publicationDate, string category, string title, int pages, decimal price, string publishingHouse, int authorId, Author author)
        {
            PublicationDate = publicationDate;
            Category = category;
            Title = title;
            Pages = pages;
            Price = price;
            PublishingHouse = publishingHouse;
            AuthorId = authorId;
            Author = author;
        }

        public Book(int id, DateTime publicationDate, string category, string title, int pages, decimal price, string publishingHouse, int authorId)
        {
            Id = id;
            PublicationDate = publicationDate;
            Category = category;
            Title = title;
            Pages = pages;
            Price = price;
            PublishingHouse = publishingHouse;
            AuthorId = authorId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Publication Date: {PublicationDate.Day}/{PublicationDate.Month}/{PublicationDate.Year}, Category: {Category}, Title: {Title}, Pages: {Pages}," +
                $"Price: {Price}, Publishing House: {PublishingHouse}, Author: {AuthorId}";
        }
    }
}
