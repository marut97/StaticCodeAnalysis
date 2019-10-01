using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisClient.Models;
using StaticCodeAnalysisClient.StaticCodeAnalysisService;

namespace StaticCodeAnalysisClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public SignInViewModel SignInViewModel { get; set; }
        public SignUpViewModel SignUpViewModel { get; set; }
        public ToolRunViewModel ToolRunViewModel { get; set; }
        public ToolTestViewModel ToolTestViewModel { get; set; }
        public ResultsViewModel ResultsViewModel { get; set; }
        public Dictionary<ViewPages, object> ViewModelsMap { get; set; }
        public StaticCodeAnalysisServiceClient CodeAnalysisServiceClient { get; set; }

        private object selectedViewModel;
        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; NotifyPropertyChanged(); }
        }

        public string Username { get; set; }
        public List<AnalysisReport> AnalysisReport { get; set; }
        public bool Result { get; set; }

        public MainViewModel()
        {
            CodeAnalysisServiceClient = new StaticCodeAnalysisServiceClient();
            SignInViewModel = new SignInViewModel(Navigate, UpdateUsername, CodeAnalysisServiceClient);
            SignUpViewModel = new SignUpViewModel(Navigate, CodeAnalysisServiceClient);
            ToolRunViewModel = new ToolRunViewModel(Navigate, UpdateReport, UpdateResult, CodeAnalysisServiceClient, Username);
            ToolTestViewModel = new ToolTestViewModel(Navigate, CodeAnalysisServiceClient, Username);
            ResultsViewModel = new ResultsViewModel(Navigate, CodeAnalysisServiceClient, Username, AnalysisReport, Result);
            SelectedViewModel = SignInViewModel;
            ViewModelsMap = new Dictionary<ViewPages, object>
            {
                //{ViewPages.SignIn, SignInViewModel},
                //{ViewPages.SignUp, SignUpViewModel},
                //{ViewPages.ToolRun, ToolRunViewModel},
                //{ViewPages.ToolTest, ToolTestViewModel},
                //{ViewPages.Results, ResultsViewModel}
                {ViewPages.SignIn, new SignInViewModel(Navigate, UpdateUsername, CodeAnalysisServiceClient)},
                {ViewPages.SignUp, new SignUpViewModel(Navigate, CodeAnalysisServiceClient)},
                {ViewPages.ToolRun, new ToolRunViewModel(Navigate, UpdateReport, UpdateResult, CodeAnalysisServiceClient, Username)},
                {ViewPages.ToolTest, new ToolTestViewModel(Navigate, CodeAnalysisServiceClient, Username)},
                {ViewPages.Results, new ResultsViewModel(Navigate, CodeAnalysisServiceClient, Username, AnalysisReport, Result)}
            };
        }

        private void Navigate(object obj)
        {
            //if (ViewModelsMap.ContainsKey((ViewPages)Convert.ToInt32(obj)))
            //{
            //    object tempViewModel;
            //    ViewModelsMap.TryGetValue((ViewPages) Convert.ToInt32(obj), out tempViewModel);
            //    SelectedViewModel = tempViewModel;
            //}
            var page = (ViewPages) Convert.ToInt32(obj);
            if (page == ViewPages.Results)
                SelectedViewModel =
                    new ResultsViewModel(Navigate, CodeAnalysisServiceClient, Username, AnalysisReport, Result);
            else if (page == ViewPages.SignIn)
                SelectedViewModel = new SignInViewModel(Navigate, UpdateUsername, CodeAnalysisServiceClient);
            else if (page == ViewPages.SignUp)
                SelectedViewModel = new SignUpViewModel(Navigate, CodeAnalysisServiceClient);
            else if (page == ViewPages.ToolRun)
                SelectedViewModel = new ToolRunViewModel(Navigate, UpdateReport, UpdateResult,
                    CodeAnalysisServiceClient,
                    Username);
            else
                SelectedViewModel = new ToolTestViewModel(Navigate, CodeAnalysisServiceClient, Username);
        }

        private void UpdateUsername(string userName)
        {
            Username = userName;
        }

        private void UpdateResult(bool result)
        {
            Result = result;
        }

        private void UpdateReport(List<AnalysisReport> report)
        {
            AnalysisReport = report;
        }
    }
}
