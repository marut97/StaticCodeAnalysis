using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisClient.ViewModels;

namespace StaticCodeAnalysisClient.Models
{
    public class SignInModel : ViewModelBase
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }
    }
}
