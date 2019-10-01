using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StaticCodeAnalysisClient.Models;
using StaticCodeAnalysisClient.StaticCodeAnalysisService;
using StaticCodeAnalysisClient.ViewModels.Commands;

namespace StaticCodeAnalysisClient.ViewModels
{
    public class ResultsViewModel : ViewModelBase
    {
        public List<AnalysisReport> AnalysisReport { get; set; }
        private bool result;

        public bool Result
        {
            get { return result; }
            set
            {
                result = value;
                NotifyPropertyChanged();
            }
        }

        private string output;
        public string Output
        {
            get { return output; }
            set { output = Result ? "GO" : "NO GO"; NotifyPropertyChanged();}
        }

        private string colour;
        public string Colour
        {
            get { return colour; }
            set { colour = Result ? "ForestGreen" : "Crimson"; NotifyPropertyChanged(); }
        }
        
        public Action<Object> Navigate { get; set; }
        public string UserName { get; set; }
        public StaticCodeAnalysisServiceClient CodeAnalysisServiceClient { get; set; }
        public ICommand RunTool { get; set; }
        public ICommand Return { get; set; }
        public ICommand Logout { get; set; }
        
        public ResultsViewModel(Action<object> navigate, StaticCodeAnalysisServiceClient codeAnalysisServiceClient, string username, List<AnalysisReport> analysisReport, bool result)
        {
            Navigate = navigate;
            UserName = username;
            AnalysisReport = analysisReport;
            Result = result;
            Output = "NO GO";
            Colour = "Crimson";
            CodeAnalysisServiceClient = codeAnalysisServiceClient;
            RunTool = new RelayCommand(o => {}, o => false);
            Return = new RelayCommand(OnReturn, o=>true);
            Logout = new RelayCommand(OnLogout, o => true);
            //AnalysisReport = new List<AnalysisReport>();
            //AnalysisReport.Add(new AnalysisReport
            //{
            //    FileName = "dummy",
            //    Line = 5,
            //    Message = "Hello world. Are you ready to see the word wrap? Are ya? I bet you arent! i bet you arent even cool enough to see the word wrap ",
            //    TypeId = "Deadly Error"
            //});
            //Result = false;
            //Output = "GO";
            //Colour = "Crimson";
        }

        private void OnLogout(object obj)
        {
            Navigate.Invoke(ViewPages.SignIn);
        }

        private void OnReturn(object obj)
        {
            Navigate.Invoke(ViewPages.ToolRun);
        }
    }
}
