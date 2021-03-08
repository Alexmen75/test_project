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
                elevator.Elevator_Call(Int32.Parse(Console.ReadLine()));
            }
        }
        
    }
    public class Elevator
    {
        public int Cursor_Left;
        public int Cursor_Top;

        private int Floors = 10;
        internal int Floor_stay = 1;
        internal int People_in = 0;
        private int Load_capacity = 5;

        private bool Door_closed = true;
        private bool In_Moove = false;

        public void Elevator_Call(int floor_call)
        {

            ConsoleInfo();
            if (floor_call < 0 || floor_call > Floors)
            {
                Console.WriteLine("такого этажа не существует");
                return;
            }
            else
            {
                Elivator_moove(floor_call);
            }
            if (floor_call == Floor_stay)
            {
                
                Door_closed = false;
                People_in_out();
                ConsoleInfo();
                Door_closed = true;
                ConsoleInfo();
            }
        }


        public void Elivator_moove(int floor_call)
        {
            ConsoleInfo();
            if (People_in > Load_capacity)
            {
                
                People_in_out(People_in);
                ConsoleInfo();
            }
            if (Door_closed==false)
            {
                ConsoleInfo();
                Console.WriteLine("Дверь открыта, Лифт ехать не может");
                ConsoleInfo();
                return;
            }

            int move = Floor_stay - floor_call < 0 ? (+1) : (-1);
            In_Moove = true;
            while (Floor_stay != floor_call)
            {
                Thread.Sleep(800);
                Floor_stay += move;
                Console.WriteLine($"Лифт на {Floor_stay}");
                ConsoleInfo();
            }
            In_Moove = false;
            ConsoleInfo();
        }


        public void People_in_out()
        {

            ConsoleInfo();
            if (In_Moove==true)
            {
                Console.WriteLine("Лифт движется, посадка невозможна");
                return;
            }
            if (People_in != 0)
            {
                ConsoleInfo();
                Console.WriteLine("Количество вышедших людей");
                People_in -= Int32.Parse(Console.ReadLine());
                if( People_in<0)
                {
                    People_in = 0;
                }
                ConsoleInfo();
            }

            ConsoleInfo();
            Console.WriteLine("Количество вошедших людей");
            People_in += Int32.Parse(Console.ReadLine());
            ConsoleInfo();
            //Console.WriteLine("Введите этаж");
            //Elevator_Call(Int32.Parse(Console.ReadLine()));
            ConsoleInfo();

        }
        public void People_in_out(int peopl_in)
        {
            ConsoleInfo();
            Console.WriteLine("слишком много людей в лифте");
            People_in -= People_in - Load_capacity;
            ConsoleInfo();
        }


        public void ConsoleInfo()
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
