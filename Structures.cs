using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Zoo
{
    
    public class Bases 
    {
       
        private List<Animal> _animal = new List<Animal>();
        private List<Cage> _cage = new List<Cage>();
        private List<Feed> _feed = new List<Feed>();


       

        public void AddAnimal(Animal animal)
        {
           
            try
            {
                if ((animal.IdAnimal < 0) || (animal.Size < 1))
                {
                    throw new Exception("Введены некорректные данные!");
                }

                _animal.Add(animal);
                Console.WriteLine("Готово! Позиция добавлена в базу.");
            }
            catch (Exception e)
            {
                Exept.Write(e);
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void AddCage(Cage cage)
        {
            
            try
            {
                if ((cage.IdCage < 0) || (cage.Number < 1) || (cage.Count_places < 1))
                {
                    throw new Exception("Введены некорректные данные!");
                }

                _cage.Add(cage);
                Console.WriteLine("Готово! Позиция добавлена в базу.");
            }
            catch (Exception e)
            {
                Exept.Write(e);
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        public void AddFeed(Feed feed)
        {
            try
            {
                if ((feed.IdFeed < 0) || (feed.Count_pieces < 1))
                {

                    throw new Exception("Введены некорректные данные!");
                }

                _feed.Add(feed);
                Console.WriteLine("Готово! Позиция добавлена в базу.");
            }
            catch(Exception e)
            {
                Exept.Write(e);
                Console.WriteLine("Exception: " + e.Message);
            }

            
        }
        
        public static Bases FromJsonFeed(string file)
        {
            var bases = new Bases();
            try
            {
                var feeds = JsonConvert.DeserializeObject<List<Feed>>(File.ReadAllText(file), new JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                });
                if (feeds != null) bases._feed.AddRange(feeds);
                Console.WriteLine($"Данные из файла {file} считаны успешно");
                return bases;
            }
            catch (Exception e)
            {
                Exept.Write(e);
                Console.WriteLine("Exception: " + e.Message);
                return bases;
            }
            finally
            {
                // Console.WriteLine("Executing finally block.");

            }
            
        }

        public void ToFileA()
        {
            using (StreamWriter file = new StreamWriter("Animal.txt", false, Encoding.UTF8))
            {
                foreach (Animal s in _animal.OfType<Animal>())
                {
                    if (s.Type_size == "мелкое")
                    {
                        file.WriteLine(s.IdAnimal + " " + s.Name + " " + s.Size + " " 
                                + s.size_feed + " " + s.Type_size + " " + (s.size_feed - 0.03) / 0.75);  
                    }
                    else
                    {
                         file.WriteLine(  s.IdAnimal + " " + s.Name + " " + s.Size + " "
                             + s.size_feed + " " + s.Type_size + " " + Convert.ToString(s.size_feed  / 1.25));
                    }
                }
                
            }
            using (StreamWriter show = new StreamWriter("AnimalShow.txt", false, Encoding.UTF8))
            {
                foreach (Animal s in _animal.OfType<Animal>())
                {
                    if (s.Type_size == "мелкое")
                    {
                        show.WriteLine("Id:" + s.IdAnimal + " Name: " + s.Name + " Size: " + s.Size + " Size_feed: "
                                + s.size_feed + " Type_size: " + s.Type_size + " Weight: " + (s.size_feed - 0.03) / 0.75);

                    }
                    else
                    {
                        show.WriteLine("Id:" + s.IdAnimal + " Name: " + s.Name + " Size: " + s.Size + " Size_feed: "
                                + s.size_feed + " Type_size: " + s.Type_size + " Weight: " + Convert.ToString(s.size_feed / 1.25)); 
                    }
                }

            }
        }
        public void ToFileC(string File)
        {

            using (StreamWriter file = new StreamWriter("Cage.txt", false, Encoding.UTF8))
            {
                
                foreach (Cage s in _cage.OfType<Cage>())
                {
                    if (s.Location == "север")
                    {
                        file.WriteLine(s.IdCage + " " + s.Location + " " + s.Number + " "
                                + s.Count_places + " " + s.size_water + " " + (s.size_water - 1)/s.Count_places);
                    }
                    else
                    {
                        file.WriteLine(s.IdCage + " " + s.Location + " " + s.Number + " "
                                + s.Count_places + " " + s.size_water + " " + (s.size_water - 0.2) / s.Count_places);
                    }
                }
                file.Close();

            }
            using (StreamWriter show = new StreamWriter("CageShow.txt", false, Encoding.UTF8))
            {
                foreach (Cage s in _cage.OfType<Cage>())
                {
                    if (s.Location == "север")
                    {
                        show.WriteLine("Id:" + s.IdCage + " Location: " + s.Location + "  Number: " + s.Number + " Count_places: "
                                + s.Count_places + " Size_water: " + s.size_water + " Count_water: " + (s.size_water - 1) / s.Count_places);

                    }
                    else
                    {
                        show.WriteLine("Id:" + s.IdCage + " Location: " + s.Location + "  Number: " + s.Number + " Count_places: "
                                + s.Count_places + " Size_water: " + s.size_water + " Count_water: " + (s.size_water - 0.2) / s.Count_places);
                    }
                }
                show.Close();
            };
            
        }


        public void ToJsonF(string file)
        {

            string outputJSONf = Newtonsoft.Json.JsonConvert.SerializeObject(_feed, Formatting.Indented);
            File.AppendAllText(file, outputJSONf + Environment.NewLine);
        }



        //public IEnumerable<Cage> GetCage()
        //{
        //    return _cage;
        //}

        
        public IEnumerable<Feed> GetFeed()
        {
            
            return _feed;
        }

        public void RemoveAnimal(Animal animal)
        {
            _animal.Remove(animal);
        }
        public void RemoveCage(Cage cage)
        {
            _cage.Remove(cage);
        }
        public void RemoveFeed(Feed feed)
        {
            _feed.Remove(feed);
        }

        
    }
   
    public abstract class Animal
    {
            public Int16 IdAnimal { get; set; }
            public string Name { get; set; }
            public Int16 Size { get; set; }
            public string Type_size { get; set; }

            public Animal(Int16 idanimal, string name, Int16 size, string type_size)
            {
                IdAnimal = idanimal;
                Name = name;
                Size = size;
                Type_size = type_size;
            }
            void Get_info_animal()
            {

            }
            public abstract double size_feed { get; }
        }

    public class Big : Animal
    {
        public double Weight { get; set; }
        
        public Big(Int16 idanimal, string name, Int16 size, string type_size, double weight) 
            : base(idanimal, name, size, type_size)
        {
            Weight = weight;
        }

       

        public override double size_feed
        {
            get { return (1.25 * Weight); }
        }
    }
    public class Small : Animal
    {
        public double Weight { get; set; }

        public Small(Int16 idanimal,string name, Int16 size, string type_size, double weight) 
            : base(idanimal,  name, size, type_size)
        {
            Weight = weight;
        }

        

        public override double size_feed
        {
            get { return (0.75* Weight + 0.03); }
        }
    }
    public abstract class Cage
    {
        public Int16 IdCage;
        public string Location;
        public Int16 Number;
        public Int16 Count_places;

        public Cage(Int16 idcage, string location, Int16 number, Int16 count_places)
        {
            IdCage = idcage;
            Location = location;
            Number = number;
            Count_places = count_places;
        }
        void Get_info_cage()
        {
        }

        public abstract double size_water { get; }

    }

    public class North : Cage
    {
        public double Count_water { get; set; }

        public North(Int16 idcage, string location, Int16 number, Int16 count_places, double count_water) 
            : base(idcage, location, number, count_places)
        {
            Count_water = count_water;
        }
        public override double size_water
        {
            get { return (Count_places * Count_water + 1); }
        }
    }

    public class South : Cage
    {
        public double Count_water { get; set; }

        public South(Int16 idcage, string location, Int16 number, Int16 count_places, double count_water) 
            : base(idcage,  location, number, count_places)
        {
            Count_water = Count_water;
        }
        public override double size_water
        {
            get { return (Count_places * Count_water + 2); }
        }
    }
    public class Feed
    {

        public Feed(Int16 idfeed, Int16 count_pieces, string type_animal, string name_feed)
        {
            IdFeed = idfeed;
            Count_pieces = count_pieces;
            Type_animal = type_animal;
            Name_feed = name_feed;
        }

        public Int16 IdFeed { get; set; }
        public Int16 Count_pieces { get; set; }
        public string Type_animal { get; set; }
        public string Name_feed { get; set; }

        


        public void ShowId(int id)
        {
            Console.WriteLine($"Вся информация по данному id = {id} найдена");
        }
       

    }

}
