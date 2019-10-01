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
    public class SignInViewModel
    {
        public Action<Object> Navigate { get; set; }
        public Action<string> UpdateUserName { get; set; }
        public StaticCodeAnalysisServiceClient CodeAnalysisServiceClient { get; set; }
        public ICommand SignIn { get; set; }
        public ICommand SignUp { get; set; }
        public SignInModel SignInModel { get; set; }
        public SignInViewModel(Action<object> navigate, Action<string> updateUsername, StaticCodeAnalysisServiceClient codeAnalysisServiceClient)
        {
            SignInModel = new SignInModel();
            Navigate = navigate;
            UpdateUserName = updateUsername;
            CodeAnalysisServiceClient = codeAnalysisServiceClient;
            SignIn = new RelayCommand(OnSignIn, o => true);
            SignUp = new RelayCommand(OnSignUp, o => true);
        }

        private void OnSignIn(object obj)
        {
            if (!CodeAnalysisServiceClient.SignIn(SignInModel.UserName, SignInModel.Password))
                MessageBox.Show("Invalid Username or Password");
            else
            {
                UpdateUserName.Invoke(SignInModel.UserName);
                Navigate.Invoke(ViewPages.ToolRun);
            }
        }

        private void OnSignUp(object obj)
        {
            Navigate.Invoke(ViewPages.SignUp);
        }
    }
}
