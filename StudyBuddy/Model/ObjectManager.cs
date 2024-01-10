using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Model
{
    public class ObjectManager<T>
    {
        private List<Observer<T>> observers = new List<Observer<T>>();
        

        // Constructor
        public ObjectManager()
        {
         
        }

        // Implement Observer pattern methods
        public void Attach(Observer<T> observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer<T> observer)
        {
            observers.Remove(observer);
        }

        // Notify observers about the change
        public void Notify(string name, object value)
        {
            foreach (var observer in observers)
            {
              
                observer.Update(name,value);
            }
        }

    }
}
