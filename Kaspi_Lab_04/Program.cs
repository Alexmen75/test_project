using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaspi_Lab_04
{
    
    class Program
    {

        static void Main(string[] args)
        {
            Elevator elevator = new Elevator();
            while(true)
            {
                
                Console.WriteLine("Введите этаж");
                elevator.ConsoleInfo();
                elevator.Call(Int32.Parse(Console.ReadLine()));
            }
        }
        
    }
    public class Elevator
    {
        //переменные для перехвата позиции курсора
        public int Cursor_Left;
        public int Cursor_Top;

        private int Floors = 10;// количество этажей
        internal int Floor_stay = 1;// Позиция лифта по этажам
        internal int People_in = 0;// количество людей в лифте
        private int Load_capacity = 5;// максимально допустимое количество людей в лифте

        private bool Door_closed = true;// состояние дверей
        private bool In_Moove = false;// состояние лифта

        public void Call(int floor_call)// метод вызова лифта 
        {

            ConsoleInfo();
            if (floor_call < 0 || floor_call > Floors)// проверка существования заданного этажа
            {
                Console.WriteLine("такого этажа не существует");
                return;
            }
            else
            {
                Moove(floor_call);
            }
            if (floor_call == Floor_stay)// на нужном ли этаже находится лифт 
            {
                
                Door_closed = false;// открываются двери
                People_in_out();// количество людей зашло/вышло
                ConsoleInfo();
                Door_closed = true;//двери закрылись
                ConsoleInfo();
            }
        }


        public void Moove(int floor_call)//Метод движения лифта 
        {
            ConsoleInfo();
            if (People_in > Load_capacity)// если количество людей в лифте превышает допустимое значение
            {
                
                People_in_out(People_in);// автоматический выводит лишних людей 
                ConsoleInfo();
            }
            if (Door_closed==false)// проверка состояния двери
            {
                ConsoleInfo();
                Console.WriteLine("Дверь открыта, Лифт ехать не может");
                ConsoleInfo();
                return;
            }

            int move = Floor_stay - floor_call < 0 ? (+1) : (-1);// проверка направления движения лифта
            In_Moove = true;// лифт движется 
            while (Floor_stay != floor_call)// движется, пока этаж лифта не будет равен нужному 
            {
                Thread.Sleep(800);// просто для симуляции
                Floor_stay += move;
                Console.WriteLine($"Лифт на {Floor_stay}");
                ConsoleInfo();
            }
            In_Moove = false;// движение прекращено
            ConsoleInfo();
        }


        public void People_in_out()//Метод входа/выхода людей 
        {

            ConsoleInfo();
            if (In_Moove==true)// нельзя зайти, если лифт движется 
            {
                Console.WriteLine("Лифт движется, посадка невозможна");
                return;
            }
            if (People_in != 0)// если количество людей не равно 0 то 
            {
                ConsoleInfo();
                Console.Write("Количество вышедших людей: ");
                People_in -= Int32.Parse(Console.ReadLine());
                if( People_in<0)// если вышло больше людей, чем было, то онулировать значение 
                {
                    People_in = 0;
                }
                ConsoleInfo();
            }

            ConsoleInfo();
            Console.Write("Количество вошедших людей: ");
            People_in += Int32.Parse(Console.ReadLine());
            ConsoleInfo();
            //Console.WriteLine("Введите этаж");
            //Elevator_Call(Int32.Parse(Console.ReadLine()));
            ConsoleInfo();

        }
        public void People_in_out(int peopl_in)// Метод убирающий лишних людей 
        {
            ConsoleInfo();
            Console.WriteLine("слишком много людей в лифте");
            People_in -= People_in - Load_capacity;
            Console.WriteLine("Лишние люди вышли");
            ConsoleInfo();
        }


        public void ConsoleInfo()//Метод вывода состояния лифта в реальном времени 
        {
            Cursor_Left = Console.CursorLeft;
            Cursor_Top = Console.CursorTop;
            Console.SetCursorPosition(50, 0);
            for (int i = 0; i < 4;i++)
            {
                Console.SetCursorPosition(50, i);
                switch (i)
                {
                    case 0:
                        Console.WriteLine($"Этаж: {Floor_stay}");
                        break;
                    case 1:
                        Console.WriteLine($"Людей в лифте: {People_in}");
                        break;
                    case 2:
                        Console.WriteLine($"Двери: {(Door_closed == true ? ("Закрыты") : ("Открыты"))}");
                        break;
                    case 3:
                        Console.WriteLine($"Состояние лифта: {(In_Moove == true ? ("В движении") : ("Стоит\t\t\t\t"))}");
                        break;
                }
                

                /*Console.WriteLine($"Этаж: {Floor_stay}");
                Console.WriteLine($"Людей в лифте: {People_in}");
                Console.WriteLine($"Двери: {(Door_closed == true ? ("Закрыты") : ("Открыты"))}");
                Console.WriteLine($"Состояние лифта: {(In_Moove == true ? ("В движении") : ("Стоит"))}");*/
            }
            Console.SetCursorPosition(Cursor_Left, Cursor_Top);
            //Thread.Sleep(800);
        }
    }
}
