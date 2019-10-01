using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StaticCodeAnalysisClient.Models;
using StaticCodeAnalysisClient.StaticCodeAnalysisService;
using StaticCodeAnalysisClient.ViewModels.Commands;

namespace StaticCodeAnalysisClient.ViewModels
{
    public class SignUpViewModel
    {
        public Action<Object> Navigate { get; set; }
        public StaticCodeAnalysisServiceClient CodeAnalysisServiceClient { get; set; }
        public ICommand SignUp { get; set; }
        public SignUpModel SignUpModel { get; set; }
        public SignUpViewModel(Action<object> navigate, StaticCodeAnalysisServiceClient codeAnalysisServiceClient)
        {
            SignUpModel = new SignUpModel();
            Navigate = navigate;
            CodeAnalysisServiceClient = codeAnalysisServiceClient;
            SignUp = new RelayCommand(OnSignUp, o => true);
        }

        private void OnSignUp(object obj)
        {
            if (SignUpModel.Password == SignUpModel.ReenterPw)
            {
                if (CodeAnalysisServiceClient.SignUp(SignUpModel.UserName, SignUpModel.Password))
                    Navigate.Invoke(ViewPages.SignIn);
                else
                    MessageBox.Show("Invalid Sign In");
            }
            else
                MessageBox.Show("Ensure Passwords are identical");
        }
    }
}
