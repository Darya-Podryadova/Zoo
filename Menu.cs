using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Menu
    {
        

        public static string task1;
        public static string task1Animal;
        public static string task1Cage;
        public static string task1Feed;

        public static int weight;
        public static string type_size;
        public static int idanimal;
        public static string name;
        public static int size;

        public static int idcage;
        public static string location;
        public static int number;
        public static int count_places;
        public static double count_water;

        public static int idfeed;
        public static int count_pieces;
        public static string type_animal;
        public static string name_feed;


        public static void Task1()
        {
            Console.WriteLine("Выберите список:");
            Console.WriteLine("1) Животные");
            Console.WriteLine("2) Клетка");
            Console.WriteLine("3) Корм");
        }

        public static void Task11()
        {
            try
            {
                Console.WriteLine("Введите id животного ");
                idanimal = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите название животного");
                name = Console.ReadLine();
                Console.WriteLine("Введите размер животного в см");
                size = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите тип животного (крупное/мелкое) (Обязательно соответствие примеру!!!)");
                type_size = Console.ReadLine();
                Console.WriteLine("Введите вес животного в граммах");
                weight = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception e)
            {
                Exept.Write(e);
                Console.WriteLine("Exception: " + e.Message);
            }
            
        }
        public static void Task12()
        {
            try
            {
                Console.WriteLine("Введите id животного в данной клетке");
                idcage = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите местоположение клетки (север/юг)(Обязательно соответствие примеру!!!)");
                location = Console.ReadLine();
                Console.WriteLine("Введите номер клетки");
                number = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите количество мест в данной клетке");
                count_places = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите количество мест для воды");
                count_water = Convert.ToDouble(Console.ReadLine());
            }
            catch(Exception e)
            {
                Exept.Write(e);
                Console.WriteLine("Exception: " + e.Message);
            }
            
        }
        public static void Task13()
        {
            try
            {
                Console.WriteLine("Введите id животного, которому идет корм");
                idfeed = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите количество еды в кг");
                count_pieces = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите тип животного");
                type_animal = Console.ReadLine();
                Console.WriteLine("Введите название корма");
                name_feed = Console.ReadLine();
            }
            catch (Exception e)
            {
                Exept.Write(e);
                Console.WriteLine("Exception: " + e.Message);
            }
           
        }
        
    }
    public class StartMenu
    {
        public int ID { get; set; }
        public string NameMenu { get; set; }

        public static List<StartMenu> menu_ ;

       
        public void ShowId(string inf)
        {
            Console.WriteLine($"{inf} Выберите операцию:");
        }
        public static bool MenuId(StartMenu obj1, StartMenu obj2)
        {
            return obj1.ID < obj2.ID;
        }

        public static void Compare(int id1, int id2, Action<int, int> com)
        {
            if (id1 > id2)

                com(id1, id2);

        }
        public static void bigger(int id1, int id2)
        {
            Console.WriteLine($"Команда с id = {id2} идет раньше чем команда с id = {id1} ");
        }
        public static void smaller(int id1, int id2)
        {
            Console.WriteLine($"Команда с id = {id1} идет позже чем команда с id = {id2} ");
        }
        
    }
    public class StartHello
    {
        public string greetings { get; set; }
        public string YourName { get; set; }


        public void Hello(string greetings, string YourName)
        {
            Console.WriteLine($"{greetings},{YourName}");
        }
    }


    
};
