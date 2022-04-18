using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace Zoo
{
 

    class Program
    {
      
        static void Main(string[] args)
        {
            Log log = new Log();
            Write write = new Write();

            HelloContrvar<StartHello> sh = new HelloContrvar<StartHello>();
            StartMenuListCovar<StartMenu> info = new StartMenuListCovar<StartMenu>();
            StartMenuListCovar<StartMenu> Menu_ = new StartMenuListCovar<StartMenu>();

            Menu_.Add(new StartMenu { ID = 3, NameMenu = "Вывести отсортированный список поставок кормов" });
            Menu_.Add(new StartMenu { ID = 1, NameMenu = "Добавить позицию" });
            Menu_.Add(new StartMenu { ID = 4, NameMenu = "Вывести лог-журнал" });
            Menu_.Add(new StartMenu { ID = 2, NameMenu = "Сохранить базу" });
            Menu_.Add(new StartMenu { ID = 0, NameMenu = "Завершить работу" });

            
            log.WriteLogs += () => write.LogInfoCons<string>("Позиции меню считаны");
            //   log.Eve();

            string filenameAnimal = "Animal.txt";
            string filenameCage = "Cage.txt";
            string filenameFeed = "Feed.json";

            log.WriteLogs += () => write.LogDebugCons<string>(ref filenameAnimal, "filenameAnimal");
           // log.Eve();
            log.WriteLogs += () => write.LogDebugCons<string>(ref filenameCage, "filenameCage");
           // log.Eve();
            log.WriteLogs += () => write.LogDebugCons<string>(ref filenameFeed, "filenameFeed");
          //  log.Eve();

            Bases BaseAnimal = new Bases();
            Bases BaseCage = new Bases();

            sh.Hello(new StartHello(), " Приветствую", "User!");

            Action<int, int> com;
            com = StartMenu.bigger;
            int tt1 = StartMenuListCovar<StartMenu>.GetId(1); 
            int  tt2 =  StartMenuListCovar< StartMenu >.GetId(3);
            StartMenu.Compare(tt1, tt2, com);
            com = StartMenu.smaller;
            StartMenu.Compare(tt1, tt2 , com);

            Console.WriteLine("");
       

            {
                try
                {

                    StreamReader sr = new StreamReader(filenameAnimal);

                    
                    string line = sr.ReadLine();

                    while (line != null && line != "")
                    {
                        string[] subs = line.Split(' ');
                        if (subs[4] == "крупное")
                        {
                            BaseAnimal.AddAnimal(new Big(Convert.ToInt16(subs[0]),
                                subs[1], Convert.ToInt16(subs[2]), subs[4], Convert.ToDouble(subs[5])));
                        }
                        if (subs[4] == "мелкое")
                        {
                            BaseAnimal.AddAnimal(new Small(Convert.ToInt16(subs[0]),
                                subs[1], Convert.ToInt16(subs[2]), subs[4], Convert.ToDouble(subs[5])));
                        }

                       
                        log.WriteLogs += () => write.LogInfoCons<string>("Животное было добавлено");
                        line = sr.ReadLine();
                    }
                    

                    sr.Close();
                    
                    log.WriteLogs += () => write.LogInfoCons<string>("Данные из файла Animal.txt считаны успешно");
                   


                }
                catch (Exception e)
                {
                    Exept.Write(e);
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                   // Console.WriteLine("Executing finally block.");
                }
            }

            {
                try
                {

                    StreamReader sr = new StreamReader(filenameCage);


                    string line = sr.ReadLine();

                    while (line != null && line != "")
                    {
                        string[] subs = line.Split(' ');
                        if (subs[1] == "север")
                        {
                            BaseCage.AddCage(new North(Convert.ToInt16(subs[0]),
                                subs[1], Convert.ToInt16(subs[2]), Convert.ToInt16(subs[4]), Convert.ToDouble(subs[5])));
                        }
                        if (subs[1] == "юг")
                        {
                            BaseCage.AddCage(new South(Convert.ToInt16(subs[0]),
                                subs[1], Convert.ToInt16(subs[2]), Convert.ToInt16(subs[4]), Convert.ToDouble(subs[5])));
                        }

                       
                        log.WriteLogs += () => write.LogInfoCons<string>("Клетка была добавлена в базу");
                        line = sr.ReadLine();
                    }

                    
                    log.WriteLogs += () => write.LogInfoCons<string>("Данные из файла Cage.txt считаны успешно"); ;
                    sr.Close();

                }
                catch (Exception e)
                {
                    Exept.Write(e);
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    //Console.WriteLine("Executing finally block.");
                }

            }
            
                Bases BaseFeed = Bases.FromJsonFeed(filenameFeed);
                List<Feed> F = (List<Feed>)BaseFeed.GetFeed();
     
            

            while (true) {
                
                
                info.infoID("Добрый день!");
                Console.WriteLine("\n");

                //foreach (StartMenu i in Menu_)
                //{
                //    Console.WriteLine($"{i.ID} {i.NameMenu}");
                    
                //}
                //Console.WriteLine("");


                StartMenuListCovar<StartMenu>.Sort(StartMenu.MenuId);

                foreach (StartMenu i in Menu_)
                {
                    Console.WriteLine($"{i.ID} {i.NameMenu}");

                }

                
                log.WriteLogs += () => write.LogInfoCons<string>("Консольное меню выведено на консоль");

                int tt0 = StartMenuListCovar<StartMenu>.GetId(0);
                log.WriteLogs += () => write.LogDebugCons<int>(ref tt0, "ID[0]");
                //log.Eve();

                int tt1_ = StartMenuListCovar<StartMenu>.GetId(1);
                log.WriteLogs += () => write.LogDebugCons<int>(ref tt1_, "ID[1]");
                //  log.Eve();

                int tt2_ = StartMenuListCovar<StartMenu>.GetId(2);
                log.WriteLogs += () => write.LogDebugCons<int>(ref tt2_, "ID[2]");
                // log.Eve();

                int tt3 = StartMenuListCovar<StartMenu>.GetId(3);
                log.WriteLogs += () => write.LogDebugCons<int>(ref tt3, "ID[3]");

                int tt4 = StartMenuListCovar<StartMenu>.GetId(4);
                log.WriteLogs += () => write.LogDebugCons<int>(ref tt4, "ID[4]");

                int Task = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                
                log.WriteLogs += () => write.LogDebugCons<int>(ref Task, "Task");
                

                if (Task == 0)
                {
                    break;
                }
                if (Task == 1)
                {
                    Menu.Task1();

                    Menu.task1 = Console.ReadLine();

                    if (Menu.task1 == "1")
                    {
                        Menu.Task11();

                        if (Menu.type_size == "крупное")
                        {
                            BaseAnimal.AddAnimal(new Big(Convert.ToInt16(Menu.idanimal), Menu.name, Convert.ToInt16(Menu.size), Menu.type_size, Menu.weight));
                        }
                        else
                        {
                            BaseAnimal.AddAnimal(new Small(Convert.ToInt16(Menu.idanimal), Menu.name, Convert.ToInt16(Menu.size), Menu.type_size, Menu.weight));
                        }
                        Console.WriteLine("Готово! Позиция добавлена в базу.");
                        
                        log.WriteLogs += () => write.LogInfoCons<string>("Позиция типа Животное добавлена в базу");


                    }
                    if (Menu.task1 == "2")
                    {
                        Menu.Task12();

                        if (Menu.location == "север")
                        {
                            BaseCage.AddCage(new North(Convert.ToInt16(Menu.idcage), Menu.location, Convert.ToInt16(Menu.number), Convert.ToInt16(Menu.count_places), Menu.count_water));
                        }
                        else
                        {
                            BaseCage.AddCage(new South(Convert.ToInt16(Menu.idcage), Menu.location, Convert.ToInt16(Menu.number), Convert.ToInt16(Menu.count_places), Menu.count_water));
                        }
                        Console.WriteLine("Готово! Позиция добавлена в базу.");
                        log.WriteLogs += () => write.LogInfoCons<string>("Позиция типа Клетка добавлена в базу");

                    }
                    if (Menu.task1 == "3")
                    {
                        Menu.Task13();
                        
                        BaseFeed.AddFeed(new Feed(Convert.ToInt16(Menu.idfeed), 
                            Convert.ToInt16(Menu.count_pieces), Menu.type_animal, Menu.name_feed));

                        

                        
                        log.WriteLogs += () => write.LogInfoCons<string>("Позиция типа Корм добавлена в базу");

                        File.WriteAllText("Feed.json", null);
                        BaseFeed.ToJsonF("Feed.json");

                        log.WriteLogs += () => write.LogInfoCons<string>("Объект сохранен в файл Feed.json");

                    } if ((Menu.task1 != "1") & (Menu.task1 != "2") & (Menu.task1 != "3") )
                    {
                        log.WriteLogs += () => write.LogErrorCons<string>("Ошибка ввода");
                        Console.WriteLine("Ошибка ввода");
                    }
                }
                if (Task == 2)
                {


                    Console.WriteLine();

                    File.Delete("Animal.txt");
                    File.Delete("AnimalShow.txt");

                    File.Create("Animal.txt").Close();
                    File.Create("AnimalShow.txt").Close();

                    BaseAnimal.ToFileA();

                    
                    log.WriteLogs += () => write.LogInfoCons<string>("Объекты сохранены в файл Animal.txt");
                    ;
                    File.Delete("Cage.txt");
                    File.Delete("CageShow.txt");

                    File.Create("Cage.txt").Close();
                    File.Create("CageShow.txt").Close();

                    BaseCage.ToFileC("Cage.txt");

                    
                    log.WriteLogs += () => write.LogInfoCons<string>("Объекты сохранены в файл Cage.txt");

                    File.WriteAllText("Feed.json", null);
                    BaseFeed.ToJsonF("Feed.json");

                    
                    log.WriteLogs += () => write.LogInfoCons<string>("Объекты сохранены в файл Feed.json");

                    Console.WriteLine("Готово! База сохранена.");
                }
                if (Task == 3)
                {
                    List<Feed> spisok = (List<Feed>)BaseFeed.GetFeed();

                    var answer = F.OrderByDescending(u => u.Name_feed);
                    foreach (Feed u in answer)
                    {
                        
                        
                            Console.WriteLine($"Id животного: {u.IdFeed} | Количество корма: {u.Count_pieces} " +
                                $"| Тип животного: {u.Type_animal} | Название корма: {u.Name_feed}");
                        
                       
                    }

                   
                    log.WriteLogs += () => write.LogInfoCons<string>("Объекты типа Feed отсортированы по убыванию по названию корма и выведены на экран");

                }
                if(Task ==4 )
                {
                    
                    log.WriteLogs += () => write.LogInfoCons<string>("Открытие лог-журнала");
                    log.Eve();
                }
                if ((Task != 1) & (Task != 2) & (Task != 3) & (Task != 4))
                {
                    log.WriteLogs += () => write.LogErrorCons<string>("Ошибка ввода, проверьте номер команды");
                    Console.WriteLine($"Ошибка ввода Команды с номером {Task} не существует");
                }

            }
        }
        
    }
}
