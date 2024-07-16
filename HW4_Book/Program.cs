using System;

namespace HW4_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = false;
            while (!showMenu)
            {
                showMenu = Menu();
            }
        }

        static bool Menu(string book = "")
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add book");
            Console.WriteLine("2) Remove book");
            Console.WriteLine("3) Show all book");
            Console.WriteLine("4) Exit");
            Console.WriteLine("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    // new Book().AddBook();
                    Console.WriteLine("Plese add book");
                    return true;
                case "2":
                    //new Remove
                    Console.WriteLine("Plese remove book");
                    return true;
                case "3":
                    Console.WriteLine("Plese shw all books");
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReliseDate { get; set; }


        public Book(string title, string author, DateTime reliseDate)
        {
            Title = title;
            Author = author;
            ReliseDate = reliseDate;
        }

    }

    public class Library
    {
        void AddBook(string title, string author, string reliseDate)
        {

        }

        void RemoveBook(string title)
        {

        }

        void GetAllBook()
        {

        }
    }
}
