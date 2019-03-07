using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int numAction=0;

            while (numAction != 3)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Регистрация");
                Console.WriteLine("2 - Вход");
                Console.WriteLine("3 - Выход");


                int.TryParse(Console.ReadLine(), out numAction);

                if (numAction != 0)
                {
                    switch (numAction)
                    {
                        case 1:
                            DataWorker.DataWriter(Registration.Start());
                            break;
                        case 2:

                            break;
                        case 3:
                            Console.WriteLine("Завершение работы");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Неверно введён номер действия. Повторите ввод");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Повторите ввод");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
