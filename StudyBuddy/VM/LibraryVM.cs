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
using StudyBuddy.View;

namespace StudyBuddy.VM
{
    public class LibraryVM:BaseVM
    {
        public ObservableCollectionListSource<String> tests { get; set; }
        public ObservableCollectionListSource<String> lessons {  get; set; }
        public static  int IDUser{get; set; }
        public Unit unit { get; set; }
        public LibraryVM() { 
        
            lessons = new ObservableCollectionListSource<String>();

            tests=new ObservableCollectionListSource<String>();
            for (int i = 0; i < 3; i++)
            {
                lessons.Add("blessings" + i.ToString());
                tests.Add("test "+i.ToString());
            }
            unit = new Unit(IDUser);
            
            unit.CreateNew();
            _units.Attach(unit);
        }
        public bool picked;
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
           
            if (picked==false)
            {
                tests.Add(name);
                Model.Test t = new Model.Test(unit.Id);
                t.CreateNew();
                _tests.Attach(t);
            }
            else
            {
                lessons.Add(name);
                Model.Lesson l = new Model.Lesson(unit.Id);
                l.CreateNew();
                _lessons.Attach(l);
            }

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
                return new DelegateCommand<object>(LessonPickedCall, LessonPickedToEvaluate);
            }
        }
        private void LessonPickedCall(object context)
        {

            picked = true;
            MessageBox.Show("Lesson selected");

        }
        private bool LessonPickedToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
        public ICommand TestPicked
        {
            get
            {
                return new DelegateCommand<object>(TestPickedCall, TestPickedToEvaluate);
            }
        }
        private void TestPickedCall(object context)
        {

            picked = false;
            MessageBox.Show("Test selected");

        }
        private bool TestPickedToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
        public ICommand PickPicked
        {
            get
            {
                return new DelegateCommand<object>(PickPickedCall, PickPickedToEvaluate);
            }
        }
        private void PickPickedCall(object context)
        {

            if(picked==false)
            {
                View.Test test = new View.Test();
                test.ShowDialog();
            }
            else
            {
                View.Lesson lesson = new View.Lesson();
                lesson.ShowDialog();
            }
            

        }
        private bool PickPickedToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }


    }
}
