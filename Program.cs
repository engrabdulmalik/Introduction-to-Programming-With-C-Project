using System;

class LibraryManagementSystem
{
    static void Main(string[] args)
    {
        string?[] books = new string?[5];
        bool[] borrowed = new bool[5];
        int borrowedCount = 0;
        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Display books");
            Console.WriteLine("4. Search for a book");
            Console.WriteLine("5. Borrow a book");
            Console.WriteLine("6. Return a book");
            Console.WriteLine("7. Exit");

            string choice = Console.ReadLine() ?? string.Empty;

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
                    RemoveBook(books, borrowed);
                    break;
                case "3":
                    DisplayBooks(books);
                    break;
                case "4":
                    SearchBook(books);
                    break;
                case "5":
                    if (borrowedCount < 3)
                    {
                        if (BorrowBook(books, borrowed))
                        {
                            borrowedCount++;
                            Console.WriteLine("Book borrowed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Book not available for borrowing.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You cannot borrow more than 3 books at a time.");
                    }
                    break;
                case "6":
                    if (ReturnBook(books, borrowed))
                    {
                        borrowedCount--;
                        Console.WriteLine("Book returned successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Book not found or not borrowed.");
                    }
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    break;
            }
        }
    }

    static bool AddBook(string?[] books)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] == null)
            {
                Console.Write("Enter the title of the book to add: ");
                string? input = Console.ReadLine();
                if (input != null)
                {
                    books[i] = input;
                }
                else
                {
                    Console.WriteLine("Invalid input. Book not added.");
                    return false;
                }
                return true;
            }
        }
        return false;
    }

    static void RemoveBook(string?[] books, bool[] borrowed)
    {
        Console.Write("Enter the title of the book to remove: ");
        string title = Console.ReadLine() ?? string.Empty;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i]?.Equals(title, StringComparison.OrdinalIgnoreCase) == true)
            {
                books[i] = null;
                borrowed[i] = false;
                Console.WriteLine("Book removed successfully!");
                return;
            }
        }

        Console.WriteLine("Book not found.");
    }

    static void DisplayBooks(string?[] books)
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

    static void SearchBook(string?[] books)
    {
        Console.Write("Enter the title of the book to search: ");
        string title = Console.ReadLine() ?? string.Empty;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i]?.Equals(title, StringComparison.OrdinalIgnoreCase) == true)
            {
                Console.WriteLine("Book is available in the collection.");
                return;
            }
        }

        Console.WriteLine("Book not found in the collection.");
    }

    static bool BorrowBook(string?[] books, bool[] borrowed)
    {
        Console.Write("Enter the title of the book to borrow: ");
        string title = Console.ReadLine() ?? string.Empty;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i]?.Equals(title, StringComparison.OrdinalIgnoreCase) == true && !borrowed[i])
            {
                borrowed[i] = true;
                return true;
            }
        }

        return false;
    }

    static bool ReturnBook(string?[] books, bool[] borrowed)
    {
        Console.Write("Enter the title of the book to return: ");
        string title = Console.ReadLine() ?? string.Empty;

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i]?.Equals(title, StringComparison.OrdinalIgnoreCase) == true && borrowed[i])
            {
                borrowed[i] = false;
                return true;
            }
        }

        return false;
    }
}