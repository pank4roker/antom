using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltikov_Kursovay
{
    /// <summary>
    ///  Класс, представляющий сам двусвязный список
    /// </summary>
    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;

        // Метод для добавления книги в начало списка
        public void AddBookToFront(Book book)
        {
            Node newNode = new Node { Data = book };
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
        }
        // Метод для добавления книги в конец списка
        public void AddBookToEnd(Book book)
        {
            Node newNode = new Node { Data = book };
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }
        // Метод для добавления книги в отсортированное по имени положение
        public void AddBookSortedByTitle(Book book)
        {
            Node newNode = new Node { Data = book };

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }

            Node current = head;
            while (current != null && string.Compare(current.Data.Title, book.Title, StringComparison.Ordinal) < 0)
            {
                current = current.Next;
            }

            if (current == head)
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            else if (current == null)
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            else
            {
                newNode.Next = current;
                newNode.Previous = current.Previous;
                current.Previous.Next = newNode;
                current.Previous = newNode;
            }
        }
        // Метод для добавления книги после определенной книги
       public void AddBookAfter(Book newBook, string title)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Title == title)
                {
                    Node newNode = new Node { Data = newBook };
                    newNode.Next = current.Next;
                    newNode.Previous = current;
                    if (current.Next != null)
                        current.Next.Previous = newNode;
                    current.Next = newNode;

                    if (current == tail)
                        tail = newNode;

                    break;
                }
                current = current.Next;
            }
        }
        // Метод для добавления книги перед определенной книги
        public void AddBookBefore(Book newBook, string title)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Title == title)
                {
                    Node newNode = new Node { Data = newBook };
                    newNode.Next = current;
                    newNode.Previous = current.Previous;
                    if (current.Previous != null)
                        current.Previous.Next = newNode;
                    current.Previous = newNode;

                    if (current == head)
                        head = newNode;

                    break;
                }
                current = current.Next;
            }
        }
        public void RemoveBook(string title)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Title == title)
                {
                    if (current == head)
                    {
                        head = head.Next;
                        if (head != null)
                            head.Previous = null;
                    }
                    else if (current == tail)
                    {
                        tail = tail.Previous;
                        if (tail != null)
                            tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                    break;
                }
                current = current.Next;
            }
        }


        // Метод для поиска книги по автору
        public void FindByAuthor(string author)
        {
            Node current = head;
            bool found = false;

            while (current != null)
            {
                if (current.Data.Author == author)
                {
                    Console.WriteLine(current.Data);
                    found = true;
                }
                current = current.Next;
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Книги данного автора не найдены.");
                Console.ResetColor();
            }
        }

        // Метод для поиска книги по названию
        public void FindByTitle(string title)
        {
            Node current = head;
            bool found = false;

            while (current != null)
            {
                if (current.Data.Title == title)
                {
                    Console.WriteLine(current.Data);
                    found = true;
                }
                current = current.Next;
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Книга с данным названием не найдена.");
                Console.ResetColor();
            }
        }
        // Метод для поиска книги по году выпуска
        public void FindByYear(int year)
        {
            if (year < DateTime.Now.Year - 1000 || year > DateTime.Now.Year)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный год выпуска.");
                Console.ResetColor();
                return;
            }

            Node current = head;
            bool found = false;

            while (current != null)
            {
                if (current.Data.Year == year)
                {
                    Console.WriteLine(current.Data);
                    found = true;
                }
                current = current.Next;
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Книги с данным годом выпуска не найдены.");
                Console.ResetColor();
            }
        }
        public void FindByAuthorAndYear(string author, int year)
        {
            Node current = head;
            bool found = false;

            while (current != null)
            {
                if (current.Data.Author == author && current.Data.Year == year)
                {
                    Console.WriteLine(current.Data);
                    found = true;
                }
                current = current.Next;
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Книги данного автора с указанным годом выпуска не найдены.");
                Console.ResetColor();
            }
        }
        // Метод для вывода всех книг в списке
        public void DisplayAllBooks()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 5)
                    {
                        string title = parts[0];
                        string author = parts[1];
                        string udk = parts[2];
                        if (int.TryParse(parts[3], out int year) && int.TryParse(parts[4], out int copies))
                        {
                            AddBookToEnd(new Book { Title = title, Author = author, UDK = udk, Year = year, Copies = copies });
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден. Будет создан новый файл при сохранении.");
            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Node current = head;
                while (current != null)
                {
                    writer.WriteLine($"{current.Data.Title};{current.Data.Author};{current.Data.UDK};{current.Data.Year};{current.Data.Copies}");
                    current = current.Next;
                }
            }
        }
    }
}
