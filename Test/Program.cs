using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static int sum = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("1-Рандомные числа\n2-ручной ввод цифр\n0-выход");//Enter после ввода числа нажимать не нужно
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 28);
            Console.Write("После выбора Enter нажимать не нужно");
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.Gray;
            int[] num = new int[10];// Объявляем массив
            
            Random rand_num = new Random();//создаем переменную рандома

            ConsoleKey key;// переменная, которая хранит информацию о нажатой клавише

            key = Console.ReadKey(true).Key;// открываем доступ для считывания
            Console.Clear();// отчищаем консоль для красоты 
            switch (key)// проверяем выбранное значение
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine("Вы выбрали рандом\n");
                    for (int i = 0; i<10;i++)
                    {
                        num[i] = rand_num.Next(0, 100);
                        Console.Write($"{i + 1} число: {num[i]}\t");
                        check_num(num[i]);
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine("Вы выбрали ручной ввод\n");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"{i + 1}-e число: ");
                        num[i] =Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(16, Console.CursorTop - 1);
                        check_num(num[i]);
                    }
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    return;
                default:
                    Console.WriteLine("Вы ввели не допустимое значение");
                    break;
            }
            Console.SetCursorPosition(50, 6);
            Console.WriteLine($"сумма всех чисел равна: {sum}");
            Console.SetCursorPosition(0, 13);
        }
        public static void check_num(int num)
        {
            if (num % 2 == 0)
            {
                Console.Write("- четное\n");
            }
            else
            {
                Console.Write("- нечетное\n");
            }
            sum += num;
        }
    }
}
