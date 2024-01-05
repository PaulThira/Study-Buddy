using Microsoft.EntityFrameworkCore.ChangeTracking;
using Prism.Commands;
using StudyBuddy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml.Linq;

namespace StudyBuddy.VM
{
    public class LibraryVM:BaseVM
    {
        public ObservableCollectionListSource<String> _tests { get; set; }
        ObservableCollectionListSource<String> _lessons {  get; set; }
        public LibraryVM() { 
        
            _lessons = new ObservableCollectionListSource<String>();

            _tests=new ObservableCollectionListSource<String>();
            for (int i = 0; i < 3; i++)
            {
                _lessons.Add("blessings" + i.ToString());
                _tests.Add("test"+i.ToString());
            }
        }
        public string name {  get; set; }
        public ICommand Add
        {
            get
            {
                return new DelegateCommand<object>(AddCall, AddToEvaluate);
            }
        }
        private void AddCall(object context)
        {
           


        }
        private bool AddToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
        public ICommand LessonPicked
        {
            get
            {
                return new DelegateCommand<object>(AddCall, AddToEvaluate);
            }
        }
        private void LessonPickedCall(object context)
        {



        }
        private bool LessonPickedToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }

    }
}
