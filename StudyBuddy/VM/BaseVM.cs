using Prism.Commands;
using StudyBuddy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyBuddy.VM
{
    public class BaseVM : INotifyPropertyChanged
    {
        

        public event PropertyChangedEventHandler PropertyChanged;
        private ObjectManager<BaseVM> central=new ObjectManager<BaseVM>();
        protected ObjectManager<Person> _person=new ObjectManager<Person>();
        protected ObjectManager<Unit> _units=new ObjectManager<Unit>();
        protected ObjectManager<Lesson> _lessons=new ObjectManager<Lesson>();
        protected ObjectManager<Test> _tests=new ObjectManager<Test>();
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
    }
}
