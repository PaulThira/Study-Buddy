using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Model
{
    public class ObjectManager<T>
    {
        private List<Observer<T>> observers = new List<Observer<T>>();
        private Dictionary<int, T> objectsById;
        private Dictionary<string, T> objectsByName;

        // Constructor
        public ObjectManager()
        {
            objectsById = new Dictionary<int, T>();
            objectsByName = new Dictionary<string, T>();
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
        public void Notify(T observer1)
        {
            foreach (var observer in observers)
            {
                observer.Update(observer1);
            }
        }

    }
}
