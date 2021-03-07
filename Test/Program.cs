using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static int sum = 0;// Создаем переменную суммы
        static void Main(string[] args)
        {
            // переменные, которые будут хранить информацию о положении курсора 
            int Cursor_L;//CorsorLeft
            int Cursor_T;//CursorTop
            while (true)// Цикл , что б программа не прекращалась, пока этого не пожелает пользователь
            {
                Console.WriteLine("1-Рандомные числа\n2-ручной ввод цифр\n0-выход");//Enter после ввода числа нажимать не нужно

                //Перехватываем положение курсора
                Cursor_L = Console.CursorLeft;
                Cursor_T = Console.CursorTop;


                Console.ForegroundColor = ConsoleColor.Green;// Изменил цвет вывода сообщяющего сообщения, что б было сразу видно 
                Console.SetCursorPosition(0, 28);// устанавливаем позицию курсора на нижние линии, что б не мешало 
                Console.Write("После выбора Enter нажимать не нужно");
                Console.SetCursorPosition(Cursor_L, Cursor_T);// возвращаем курсор на место
                Console.ForegroundColor = ConsoleColor.Gray;// возвращаем цвет


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
                        for (int i = 0; i < 10; i++)
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
                            string s_num = Console.ReadLine();
                            if (Int32.TryParse(s_num, out num[i]))// проверяем введенное значение
                            {
                                //num[i] = Convert.ToInt32(s_num);
                                Console.SetCursorPosition(16, Console.CursorTop - 1);// так как после команды ReadLine курсор уходит вниз надо вернуть его наместо, для красивого вывода  
                                check_num(num[i]);
                            }
                            else// если введено значение, которое не предусмотренно программой 
                            {
                                i--;// в случае если пользователь ввел не допустимое значение , то возвращаем цикл назад 

                                Cursor_L = Console.CursorLeft;
                                Cursor_T = Console.CursorTop;

                                // блок вывода сообщения 
                                Console.SetCursorPosition(0, 28);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Введено недопустимое значение. Нужно ввести целое число\nДля продолжения нажмите любую клавишу");
                                Console.ReadKey();
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.SetCursorPosition(0, 28);
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t");// Отчистка выведенного ранее сообщения
                                Console.Write("\t\t\t\t\t\t\t\t\t\t\t");//Да, МАКСИМАЛЬНО отвратительно, но лучше варианта я, пока, не нашел
                                Console.SetCursorPosition(Cursor_L, Cursor_T - 1);
                                Console.Write("\t\t\t\t\t\t\t\t\t\t\t");//Да , все еще отвратительно, зато вывод красивый
                                Console.SetCursorPosition(0, Cursor_T - 1);
                            }
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
                Console.Write($"сумма всех чисел равна: {sum}   ");
                sum = 0;
                Console.SetCursorPosition(0, 28);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Для продолжения нажмите любую клавишу");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                
            }
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
