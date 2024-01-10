using Prism.Commands;
using StudyBuddy.Model;
using StudyBuddy.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace StudyBuddy.VM
{
    public class LogInSignUpUserVM:BaseVM
    {
        
        public string name {  get; set; }
        public string password { get; set; }

        public LogInSignUpUserVM() {
            name = "initial";
            password = "broke";
           
        }
        public ICommand SignUp
        {
            get
            {
                return new DelegateCommand<object>(SignUpCall, SignUpToEvaluate);
            }
        }
        private void SignUpCall(object context)
        {
            Person P = new Person();
            
            Person PBlank = new Person();
            P.GetByName(name);
           
            if (P.GetByName(name) == false) 
            {
                P.name = name;
                P.password = password;
                P.CreateNew();
            
                _person.Attach(P);
                MessageBox.Show("Sign Up done");
                
            }
            else
            {
                MessageBox.Show("Username already taken");
            }

            MessageBox.Show("Success");


        }
        private bool SignUpToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
        public ICommand LogIn
        {
            get
            {
                return new DelegateCommand<object>(LogInCall, LogInToEvaluate);
            }
        }
        private void LogInCall(object context)
        {
            Person PBlank = new Person();
            if (PBlank.UserLogIn(name, password) == true)
            {
                PBlank.name = name;
                PBlank.password = password;
                _person.Attach(PBlank);
                UserMenu U=new UserMenu(PBlank.Id);
                U.ShowDialog();
                





            }
            else
            {
                PBlank.AddStrike(name);
                _person.Notify("strikes",PBlank.strikes+1);
            }
        }
            private bool LogInToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }

    }
}
