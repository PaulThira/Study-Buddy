using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyBuddy.VM
{
    public class UserOptionVM:BaseVM
    {
        public int UserID {  get; set; }    
        public UserOptionVM(int userID)
        {
            UserID = userID;
        }
        public UserOptionVM()
        {
            UserID = 1;
        }
        public ICommand Feed
        {
            get
            {
                return new DelegateCommand<object>(FeedCall, FeedToEvaluate);
            }
        }
        private void FeedCall(object context)
        {

            View.Feed f = new View.Feed(UserID);
            f.ShowDialog();
            

        }
        private bool FeedToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
        public ICommand Library
        {
            get
            {
                return new DelegateCommand<object>(LibraryCall, LibraryToEvaluate);
            }
        }
        private void LibraryCall(object context)
        {

            View.Library l =new View.Library(UserID);
            l.ShowDialog();

        }
        private bool LibraryToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
        
    }
}
