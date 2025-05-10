using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nLibrary Book Management");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. View all books");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter book author: ");
                    string author = Console.ReadLine();
                    library.AddBook(new Book(title, author));
                    Console.WriteLine("Book added.");
                    break;

                case "2":
                    library.DisplayBooks();
                    break;

                case "3":
                    Console.Write("Enter title of book to borrow: ");
                    string borrowTitle = Console.ReadLine();
                    library.BorrowBook(borrowTitle);
                    break;

                case "4":
                    Console.Write("Enter title of book to return: ");
                    string returnTitle = Console.ReadLine();
                    library.ReturnBook(returnTitle);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsBorrowed { get; set; }

    public Book(string title, string author)
    {
        this.Title = title;
        this.Author = author;
        this.IsBorrowed = false;
    }

    public void DisplayInfo()
    {
        string status = IsBorrowed ? "Borrowed" : "Available";
        Console.WriteLine($"Title: {Title}, Author: {Author}, Status: {status}");
    }
}

public class Library
{
    public List<Book> Books { get; set; } = new List<Book>();
    private readonly string filePath = "books.txt";

    public Library()
    {
        LoadBooksFromFile();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
        SaveBooksToFile();
    }

    public void DisplayBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        foreach (var book in Books)
        {
            book.DisplayInfo();
        }
    }

    public void BorrowBook(string title)
    {
        Book book = Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (book == null)
        {
            Console.WriteLine("Book not found.");
        }
        else if (book.IsBorrowed)
        {
            Console.WriteLine("Sorry, the book is already borrowed.");
        }
        else
        {
            book.IsBorrowed = true;
            SaveBooksToFile();
            Console.WriteLine("Book borrowed successfully.");
        }
    }

    public void ReturnBook(string title)
    {
        Book book = Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (book == null)
        {
            Console.WriteLine("Book not found.");
        }
        else if (!book.IsBorrowed)
        {
            Console.WriteLine("This book wasn't borrowed.");
        }
        else
        {
            book.IsBorrowed = false;
            SaveBooksToFile();
            Console.WriteLine("Book returned successfully.");
        }
    }

    private void SaveBooksToFile()
    {
        List<string> lines = new List<string>();
        foreach (var book in Books)
        {
            lines.Add($"{book.Title}|{book.Author}|{book.IsBorrowed}");
        }
        File.WriteAllLines(filePath, lines);
    }

    private void LoadBooksFromFile()
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close(); 
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                string title = parts[0];
                string author = parts[1];
                bool isBorrowed = bool.Parse(parts[2]);
                Books.Add(new Book(title, author) { IsBorrowed = isBorrowed });
            }
        }
    }
}