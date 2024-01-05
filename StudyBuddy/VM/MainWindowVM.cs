using Prism.Commands;
using StudyBuddy.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace StudyBuddy.VM
{
    public class MainWindowVM:BaseVM
    {
        public ICommand New
        {
            get
            {
                return new DelegateCommand<object>(NewCall, NewToEvaluate);
            }
        }
        private void NewCall(object context)
        {
            UserLoginSignupxaml U=new UserLoginSignupxaml();
            U.ShowDialog();



        }
        private bool NewToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
    }
}
