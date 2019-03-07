using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    public class Registration
    {
        public static User Start()
        {
            var newUser = new User();

            bool isSuccessSet = false;

            while (!isSuccessSet)
            {
                Console.WriteLine("Введите email:");
                isSuccessSet = newUser.SetEmail(Console.ReadLine());

                if (!isSuccessSet)
                {
                    Console.WriteLine("Введите корректный email");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Email установлен");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            isSuccessSet = false;

            while (!isSuccessSet)
            {
                Console.WriteLine("Введите пароль:");
                isSuccessSet = newUser.SetPassword(Console.ReadLine());

                if (!isSuccessSet)
                {
                    Console.WriteLine("Пароль должен содержать заглавные и строчные буквы, специальные символы и цифры,\n\t и не должен содержать пробелы");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Пароль установлен");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            isSuccessSet = false;

            while (!isSuccessSet)
            {
                Console.WriteLine("Введите номер телефона:");
                isSuccessSet = newUser.SetPhoneNumber(Console.ReadLine());

                if (!isSuccessSet)
                {
                    Console.WriteLine("Номер телефона должен содержать только цифры");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Номер телефона установлен");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            isSuccessSet = false;

            while (!isSuccessSet)
            {
                Console.WriteLine("Введите город:");
                isSuccessSet = newUser.SetCity(Console.ReadLine());

                if (!isSuccessSet)
                {
                    Console.WriteLine("Поле город не может быть пустым");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Город установлен");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            isSuccessSet = false;

            while (!isSuccessSet)
            {
                Console.WriteLine("Введите возраст:");
                isSuccessSet = newUser.SetAge(Console.ReadLine());

                if (!isSuccessSet)
                {
                    Console.WriteLine("Возраст введён не верно");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Возраст установлен");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            isSuccessSet = false;

            return newUser;
        }
    }
}
