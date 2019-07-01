using System;
using System.Collections.Generic;
using System.Text;

namespace AdoExamPattern
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        public Author() { }

        public Author(string firstName, string lastName, DateTime birthDate, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
        }
        public Author(int id, string firstName, string lastName, DateTime birthDate, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {FirstName} {LastName}, BirthDate: {BirthDate}, Email: {Email}\n";
        }
    }
}
