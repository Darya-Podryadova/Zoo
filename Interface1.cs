using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Zoo
{
    public interface IStartMenuListCovar<out T> 
    {
        T infoID( string inf);       

    }
   
    public class StartMenuListCovar<T>: IEnumerable<T>, IStartMenuListCovar<T> where T : StartMenu, new()
    {
        private static List<T> menu_;

        public StartMenuListCovar()
        {
            menu_ = new List<T>();
        }
       

        public IEnumerator<T> GetEnumerator()
        {
            return menu_.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
      
        public T infoID(string id)
        {
            T item = new T();
            item.ShowId(id);
            return item;
        }

        public void Add(T arg)
        {
            menu_.Add(arg);
        }
        public void RemoveAt(int index)
        {
            if (menu_.Count <= index)
                throw new IndexOutOfRangeException("Error!");
            else
                menu_.RemoveAt(index);
        }

        public static int GetId(int id)
        {
            try
            {
                return menu_[id].ID;
            }
            catch (Exception e)
            {
                Exept.Write(e);
                Console.WriteLine("Exception: " + e.Message);
                return -1;
            }
            finally
            {
                // Console.WriteLine("Executing finally block.");

            }



        }

        public static void Sort( Func<T, T, bool> res)
        {

            bool mySort = true;
            do
            {
                mySort = false;
                for (int i = 0; i < menu_.Count - 1; i++)
                {
                    if (res(menu_[i + 1], menu_[i]))
                    {
                        T j = menu_[i];
                        menu_[i] = menu_[i + 1];
                        menu_[i + 1] = j;
                        mySort = true;
                    }
                }
            } while (mySort);
        }

        public delegate void Action<T,T1>(T obj);
       
    }



    public interface IHelloContrvar<in T>
    {
        void Hello(T start_, string greetings, string YourName);
       
    }

    public class HelloContrvar<T>: IHelloContrvar<T> where T: StartHello
    {
        public void Hello( T start_, string greetings, string YourName)
        {
            start_.Hello(greetings, YourName);
        }
    }

}
