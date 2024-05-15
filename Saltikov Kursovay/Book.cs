using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltikov_Kursovay
{
    /// <summary>
    ///  Класс, представляющий книгу
    /// </summary>
    public class Book
    {
        public string UDK { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Copies { get; set; }

        public override string ToString()
        {
            return $"Название: {Title}, Автор: {Author}, Год выпуска: {Year}, Номер УДК: {UDK}, Кoличество экземпляров: {Copies} ";
        }
    }
}
