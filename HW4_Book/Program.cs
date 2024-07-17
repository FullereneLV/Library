using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        static bool Menu()
        {
            var myLibraty = new Library();
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
                    myLibraty.AddBook();
                    PauseBeforeContinuing();
                    return false;
                case "2":
                    myLibraty.RemoveBook();
                    PauseBeforeContinuing();
                    return false;
                case "3":
                    myLibraty.GetAllBook();
                    PauseBeforeContinuing();
                    return false;
                case "4":
                    return true;
                default:
                    Console.WriteLine("Invalid. Please try again.");
                    PauseBeforeContinuing();
                    return false;
            }
        }

        static void PauseBeforeContinuing()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReliseDate { get; set; }

        public Dictionary<string, string> dictTitleAuthor = new Dictionary<string, string>();
        public Dictionary<string, DateTime> dictTitleDateRealise = new Dictionary<string, DateTime>();

        public string EnterTitleBook()
        {
            var title = String.Empty;
            Console.Clear();
            Console.WriteLine("Please enter title a book:");
            try
            {
                title = Console.ReadLine();
                dictTitleAuthor.Add(title, string.Empty);
                var all = dictTitleAuthor;
            }catch(ArgumentException e)
            {
                Console.WriteLine("Try again " + e.Message);
            }

            return title;
        }

        public void EnterAuthorBook(string titleBook)
        {
            Console.WriteLine($"Please enter author a book {titleBook}:");
            var author = Console.ReadLine();
            dictTitleAuthor[titleBook] = author;
        }

        public void EnterReliseDate(string titleBook)
        {
            Console.WriteLine($"Please enter relise date a book {titleBook}  year in \"yyyy\" format:");
            var date = Console.ReadLine();
            try
            {

                DateTime parsedDate = DateTime.ParseExact(date, "yyyy", CultureInfo.InvariantCulture);
                dictTitleDateRealise[titleBook] = parsedDate;
            }
            catch(FormatException e)
            {
                Console.WriteLine("Error: Please write year " + e.Message);
            }
        }
    }

    class Library
    {
        Book book = new Book();
        
        public void AddBook()
        {
            var titleBook = book.EnterTitleBook();
            book.EnterAuthorBook(titleBook);
            book.EnterReliseDate(titleBook);
            Console.WriteLine("Successfully added to the library.");
        }

        public void RemoveBook()
        {
            Console.Clear();
            Console.WriteLine("Please enter title book for remove:");
            var title = Console.ReadLine();
            Console.WriteLine($"Do you want to remove the book {title}: Y/N");
            var value = Console.ReadLine();
            if(value == "y" || value == "Y")
            {
                try
                {
                    book.dictTitleAuthor.Remove(title);
                    book.dictTitleDateRealise.Remove(title);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Not exist " + e.Message);
                }
            }
        }

        public void GetAllBook()
        {
            Console.Clear();
            Console.WriteLine("These are all books in libary:");
            var author = book.dictTitleAuthor;
            for (int i = 0; i <author.Count; i++)
            {
                Console.WriteLine("Title: " + author.ElementAt(i).Key
                    + " Author: " + author.ElementAt(i).Value + "Realise Date " 
                    + book.dictTitleDateRealise.ElementAt(i).Value);
            }
        }
    }
}
