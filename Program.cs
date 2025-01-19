using System;

class LibraryManagementSystem
{
    static void Main(string[] args)
    {
        string[] books = new string[5];
        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Display books");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (AddBook(books))
                    {
                        Console.WriteLine("Book added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No more books can be added.");
                    }
                    break;
                case "2":
                    RemoveBook(books);
                    break;
                case "3":
                    DisplayBooks(books);
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    break;
            }
        }
    }

    static bool AddBook(string[] books)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] == null)
            {
                Console.Write("Enter the title of the book to add: ");
                books[i] = Console.ReadLine();
                return true;
            }
        }
        return false;
    }

    static void RemoveBook(string[] books)
    {
        Console.Write("Enter the title of the book to remove: ");
        string title = Console.ReadLine();

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != null && books[i].Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                books[i] = null;
                Console.WriteLine("Book removed successfully!");
                return;
            }
        }

        Console.WriteLine("Book not found.");
    }

    static void DisplayBooks(string[] books)
    {
        Console.WriteLine("Current list of books:");
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != null)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
        }
    }
}
