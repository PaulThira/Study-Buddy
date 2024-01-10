using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyBuddy.VM
{
    public class TestVM:BaseVM
    {
        public int score {  get; set; }
        public List<int> questionIDs { get; set; }
        public string question {  get; set; }
        public List<string> answers { get; set; }
        public static int IDUnit {  get; set; }
        public int rightAnswer {  get; set; }
        public int currentQuestion {  get; set; }
        public TestVM() { 
                questionIDs = new List<int>();
                question = "default";
                answers = new List<string>();
                rightAnswer = 0;
                currentQuestion = 0;

        }
        public ICommand Next
        {
            get
            {
                return new DelegateCommand<object>(NextCall, NextToEvaluate);
            }
        }
        private void NextCall(object context)
        {



        }
        private bool NextToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
        public ICommand Back
        {
            get
            {
                return new DelegateCommand<object>(BackCall, BackToEvaluate);
            }
        }
        private void BackCall(object context)
        {



        }
        private bool BackToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }

    }
}
