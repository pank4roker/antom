using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltikov_Kursovay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Kirill\Downloads\Kyrsovay-anton-patch-1\Kyrsovay-anton2121212-patch-1\Saltikov Kursovay\File.txt";
            DoublyLinkedList library = new DoublyLinkedList();
            library.LoadFromFile(filePath);
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\tМеню:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Добавить книгу в начало списка");
                Console.WriteLine("2. Добавить книгу в конец списка");
                Console.WriteLine("3. Добавить книгу в позицию, отсортированную по имени в алфавитном порядке");
                Console.WriteLine("4. Добавление книги после определенной книги");
                Console.WriteLine("5. Добавление книги перед определенной книги");
                Console.WriteLine("6. Удаление данных о списываемых книгах");
                Console.WriteLine("7. Вывести сведения о наличии книг в библиотеке, упорядоченные по годам издания");
                Console.WriteLine("8. Поиск книг определенного автора и года издания");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("9. Выход");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Выберите действие: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректные ввод,повторите снова!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\tДобавить книгу в начало списка:");
                        Console.Write("Введите название книги: ");
                        string title1 = Console.ReadLine();
                        Console.Write("Введите автора книги: ");
                        string author1 = Console.ReadLine();
                        Console.Write("Введите номер УДК: ");
                        string udk1 = Console.ReadLine();
                        Console.Write("Введите год выпуска книги: ");
                        if (int.TryParse(Console.ReadLine(), out int year1))
                        {
                            Console.Write("Введите количество экземпляров: ");
                            if (int.TryParse(Console.ReadLine(), out int copies1))
                            {
                                library.AddBookToFront(new Book { Title = title1, Author = author1, UDK = udk1, Year = year1, Copies = copies1 });
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\tНовая книга успешно добавлена в начало списка!\n");
                            }
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\tДобавить книгу в конец списка:");
                        Console.Write("Введите название книги: ");
                        string title2 = Console.ReadLine();
                        Console.Write("Введите автора книги: ");
                        string author2 = Console.ReadLine();
                        Console.Write("Введите номер УДК: ");
                        string udk2 = Console.ReadLine();
                        Console.Write("Введите год выпуска книги: ");
                        if (int.TryParse(Console.ReadLine(), out int year2))
                        {
                            Console.Write("Введите количество экземпляров: ");
                            if (int.TryParse(Console.ReadLine(), out int copies2))
                            {
                                library.AddBookToEnd(new Book { Title = title2, Author = author2, UDK = udk2, Year = year2, Copies = copies2 });
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\tНовая книга успешно добавлена в конец списка!\n");
                            }
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\tДобавить книгу в позицию, отсортированную по имени в алфавитном порядке:");
                        Console.Write("Введите название книги: ");
                        string title3 = Console.ReadLine();
                        Console.Write("Введите автора книги: ");
                        string author3 = Console.ReadLine();
                        Console.Write("Введите номер УДК: ");
                        string udk3 = Console.ReadLine();
                        Console.Write("Введите год выпуска книги: ");
                        if (int.TryParse(Console.ReadLine(), out int year3))
                        {
                            Console.Write("Введите количество экземпляров: ");
                            if (int.TryParse(Console.ReadLine(), out int copies3))
                            {
                                library.AddBookSortedByTitle(new Book { Title = title3, Author = author3, UDK = udk3, Year = year3, Copies = copies3 });
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\tНовая книга успешно добавлена в позицию, отсортированную по имени в алфавитном порядке!\n");
                            }
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("\tДобавление книги после определенной книги:");
                        Console.Write("Введите название книги для добавления: ");
                        string title4 = Console.ReadLine();
                        Console.Write("Введите автора книги: ");
                        string author4 = Console.ReadLine();
                        Console.Write("Введите номер УДК: ");
                        string udk4 = Console.ReadLine();
                        Console.Write("Введите год выпуска книги: ");
                        if (int.TryParse(Console.ReadLine(), out int year4))
                        {
                            Console.Write("Введите количество экземпляров: ");
                            if (int.TryParse(Console.ReadLine(), out int copies4))
                            {
                                Book newBook = new Book { Title = title4, Author = author4, UDK = udk4, Year = year4, Copies = copies4 };
                                Console.Write("Введите название книги, после которой нужно добавить: ");
                                string afterTitle = Console.ReadLine();
                                library.AddBookAfter(newBook, afterTitle);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\tНовая книга успешно добавлена после определенной книги!\n");
                            }
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("\tДобавление книги перед определенной книги:");
                        Console.Write("Введите название книги для добавления: ");
                        string title5 = Console.ReadLine();
                        Console.Write("Введите автора книги: ");
                        string author5 = Console.ReadLine();
                        Console.Write("Введите номер УДК: ");
                        string udk5 = Console.ReadLine();
                        Console.Write("Введите год выпуска книги: ");
                        if (int.TryParse(Console.ReadLine(), out int year5))
                        {
                            Console.Write("Введите количество экземпляров: ");
                            if (int.TryParse(Console.ReadLine(), out int copies5))
                            {
                                Book newBook = new Book { Title = title5, Author = author5, UDK = udk5, Year = year5, Copies = copies5 };
                                Console.Write("Введите название книги, перед которой нужно добавить: ");
                                string beforeTitle = Console.ReadLine();
                                library.AddBookBefore(newBook, beforeTitle);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\tНовая книга успешно добавлена перед определенной книги!\n");
                            }
                        }
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("\tУдаление данных о списываемых книгах:");
                        Console.Write("Введите название книги для удаления: ");
                        string title6 = Console.ReadLine();
                        library.RemoveBook(title6);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\tКнига успешно была удалена!\n");
                        break;

                    case 7:
                        Console.WriteLine("\tСведения о наличии книг в библиотеке, упорядоченные по годам издания:");
                        library.DisplayAllBooks();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("1. Поиск книг по автору");
                        Console.WriteLine("2. Поиск книг по автору и году");
                        Console.Write("Выберите действие: ");
                        if (int.TryParse(Console.ReadLine(), out int searchChoice))
                        {
                            switch (searchChoice)
                            {
                                case 1:
                                    {
                                        Console.Write("Введите автора книги: ");
                                        string author = Console.ReadLine();
                                        library.FindByAuthor(author);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Write("Введите автора книги: ");
                                        string author = Console.ReadLine();
                                        Console.Write("Введите год выпуска книги: ");
                                        if (int.TryParse(Console.ReadLine(), out int year))
                                        {
                                            library.FindByAuthorAndYear(author, year);
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    case 9:
                        library.SaveToFile(filePath);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Программа завершена.");
                        return;
                }
            }
        }
        
    }
}
