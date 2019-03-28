using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2019._03._19HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int idPeople;
            bool isESC;
            do
            {
                do
                {
                    Console.WriteLine("Введите порядковый номер персонажа");
                } while (!(int.TryParse(Console.ReadLine(), out idPeople) && idPeople > 0));

                var peopleHandler = new PeopleHandler();

                var people = peopleHandler.PeopleLoader(idPeople);

                peopleHandler.ShowPeople(people);

                Console.WriteLine("Для завершения нажмите Esc");
                var key = Console.ReadKey();
                Console.Clear();
                isESC = key.Key == ConsoleKey.Escape;
            } while (!isESC);

            // не разобрался по чему при десерарилизации из json пропадают значения от HairColor до BirthYear

        }
    }
}
