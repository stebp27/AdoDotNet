using System;

namespace AdoExamPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var UI = new UserInterface(new DataProcessor(new DBDataSource()));
            UI.MainMenu();
        }
    }
}
