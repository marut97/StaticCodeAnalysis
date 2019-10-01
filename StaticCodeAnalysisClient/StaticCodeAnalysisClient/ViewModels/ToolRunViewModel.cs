using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StaticCodeAnalysisClient.Models;
using StaticCodeAnalysisClient.StaticCodeAnalysisService;
using StaticCodeAnalysisClient.ViewModels.Commands;

namespace StaticCodeAnalysisClient.ViewModels
{
    public class ToolRunViewModel : ViewModelBase
    {
        public Action<List<AnalysisReport>> UpdateReport { get; set; }
        public Action<bool> UpdateResult { get; set; }
        public ToolRunModel ToolRunModel { get; set; }
        private ToolStatusModel toolStatusModel;
        public ToolStatusModel ToolStatusModel
        {
            get { return toolStatusModel;}
            set
            {
                toolStatusModel = value;
                NotifyPropertyChanged();
            } }
        public Action<Object> Navigate { get; set; }
        public string UserName { get; set; }
        public StaticCodeAnalysisServiceClient CodeAnalysisServiceClient { get; set; }
        public ICommand RunTool { get; set; }
        public ICommand TestTool { get; set; }
        public ICommand Logout { get; set; }
        public ICommand RecentSelected { get; set; }
        public ICommand GateCommand { get; set; }
        public ObservableCollection<RepositoryDetailsModel> UserRepos { get; set; }

        private RepositoryDetailsModel selectedRepository;

        public RepositoryDetailsModel SelectedRepository
        {
            get { return selectedRepository;}
            set
            {
                selectedRepository = value;
                NotifyPropertyChanged();
            }
        }



        public ToolRunViewModel(Action<object> navigate, Action<List<AnalysisReport>> updateReport, Action<bool> updateResult, StaticCodeAnalysisServiceClient codeAnalysisServiceClient, string username)
        {
            Navigate = navigate;
            UserName = username;
            UpdateReport = updateReport;
            UpdateResult = updateResult;
            CodeAnalysisServiceClient = codeAnalysisServiceClient;
            ToolRunModel = new ToolRunModel();
            InitializeToolRunModel();
            ToolStatusModel = new ToolStatusModel();
            ToolStatusModel.StatusMessage = "Please upload file";
            ToolStatusModel.StatusImage = @"../Images/addInputFile.png";
            RunTool = new RelayCommand(OnToolRun, o => true);
            TestTool = new RelayCommand(OnToolTest, CanToolTest);
            Logout = new RelayCommand(OnLogout, o => true);
            RecentSelected = new RelayCommand(OnSelection, o => true);
            //GateCommand = new RelayCommand();

        }

        private void OnSelection(object obj)
        {
            ToolRunModel.RepoPath = SelectedRepository.Repository;
            ToolRunModel.Branch = SelectedRepository.Branch;
            ToolRunModel.SelectedTool = (Tools)Convert.ToInt32(SelectedRepository.Tool);
        }

        //private void OnGateCommand(object obj)
        //{
        //    ToolRunModel.GateType=
        //}

        private ObservableCollection<RepositoryDetailsModel> ParseRecentRepos(GatingResult[] results)
        {
            ObservableCollection<RepositoryDetailsModel> repositoryDetailsModels = new ObservableCollection<RepositoryDetailsModel>();
            for (int i = 0; i < results.Length; i++)
            {
                
                var result = new RepositoryDetailsModel();
                if (results[i].Reository.LastIndexOf('\\') > 0)
                    result.Repository = results[i].Reository.Substring(results[i].Reository.LastIndexOf('\\')+1);
                else
                    result.Repository = results[i].Reository;
                result.Branch = results[i].Branch;
                result.DateTime = results[i].DateTime;
                result.Tool = results[i].Tool.ToString();
                result.Errors = results[i].NoOfError.ToString();
                result.Colour = results[i].Result ? "ForestGreen" : "Crimson";
                repositoryDetailsModels.Add(result);
            }
            //repositoryDetailsModels.Add(new RepositoryDetailsModel
            //{
            //    Branch = "master",
            //    Colour = "Crimson",
            //    DateTime = DateTime.Now.ToString(),
            //    Errors = "10",
            //    Repository = "dummyRepo.git",
            //    Tool = Tools.Resharper.ToString()
            //});
            //repositoryDetailsModels.Add(new RepositoryDetailsModel
            //{
            //    Branch = "notMaster",
            //    Colour = "ForestGreen",
            //    DateTime = DateTime.Now.ToString(),
            //    Errors = "6",
            //    Repository = "abc/dummyRepoNew.git",
            //    Tool = Tools.Resharper.ToString()
            //});
            return repositoryDetailsModels;
        }


        private void InitializeToolRunModel()
        {
            ToolRunModel.Branch = "master";
            ToolRunModel.GateThreshold = -1;
            ToolRunModel.GateType = false;
            ToolRunModel.RepoType = false;
            ToolRunModel.AllTools = new Dictionary<Tools, string>();
            ToolRunModel.AllTools.Add(Tools.PVS, Tools.PVS.ToString());
            ToolRunModel.AllTools.Add(Tools.Resharper, Tools.Resharper.ToString());
            ToolRunModel.AllTools.Add(Tools.Simian, Tools.Simian.ToString());

            var results = CodeAnalysisServiceClient.GetRecentResults(UserName);
            UserRepos = ParseRecentRepos(results);
        }

        private void OnToolRun(object obj)
        {
            if (ToolRunModel.RepoType)
            {
                DownloadRepo();
            }
            else
                ExecuteTool();

        }

        private void OnToolTest(object obj)
        {
            Navigate.Invoke(ViewPages.ToolTest);
        }

        private bool CanToolTest(object obj)
        {
            return ToolRunModel.SelectedTool == Tools.Simian;
        }

        private void OnLogout(object obj)
        {
            Navigate.Invoke(ViewPages.SignIn);
        }

        private void DownloadRepo()
        {
            ToolStatusModel.StatusMessage = "Sit Tight. The Minions are Downloading your repository....";
            ToolStatusModel.StatusImage = "../Images/Downloading.png";
            if (!CodeAnalysisServiceClient.Download(ToolRunModel.RepoPath, ToolRunModel.Branch))
            {
                ToolStatusModel.StatusMessage = "Oops. The Minion couldnt reach the repository. \nTry again with a different minion";
                ToolStatusModel.StatusImage = "../Images/DownloadFailed.png";
            }
            else
                ExecuteTool();
        }

        private void ExecuteTool()
        {
            ToolStatusModel.StatusMessage = "Minions hard at work running the Tool....";
            ToolStatusModel.StatusImage = "../Images/RunningTool.png";
            if (!CodeAnalysisServiceClient.InvokeTool(ToolRunModel.RepoPath, ToolRunModel.SelectedTool))
            {
                ToolStatusModel.StatusMessage = "Oops. A Minion slipped while Running the tool. \nPlease Try Again";
                ToolStatusModel.StatusImage = "../Images/RunToolFailed.png";
            }
            else
                ParseReport();
        }

        private void ParseReport()
        {
            ToolStatusModel.StatusMessage = "Minions are Parsing the Report....";
            ToolStatusModel.StatusImage = "../Images/ParsingReport.png";
            AnalysisReport[] parsedReport;
            try
            {
                parsedReport = CodeAnalysisServiceClient.ParseReport(ToolRunModel.SelectedTool,
                    ToolRunModel.RepoPath, ToolRunModel.Branch);
            }
            catch
            {
                parsedReport = new AnalysisReport[1];
                parsedReport[0] = new AnalysisReport
                {
                    FileName = ToolRunModel.RepoPath,
                    Line = 0,
                    Message = "Report too big to transfer",
                    TypeId = "Warning"
                };
            }

            if(parsedReport == null)
            {
                ToolStatusModel.StatusMessage = "Oops. The minion couldnt understand the report. \nTry again when the minion has has studied it further";
                ToolStatusModel.StatusImage = "../Images/ParseFailed.png";
            }
            else
            {
                UpdateReport(parsedReport.ToList());
                GetResult();
            }
        }

        private void GetResult()
        {
            bool result;
            ToolStatusModel.StatusMessage = "Almost done. Minions are Putting Finishing Touches on the Report....";
            ToolStatusModel.StatusImage = "../Images/GetResult.png";
            if(!ToolRunModel.GateType)
                result = CodeAnalysisServiceClient.GetResult(-1, ToolRunModel.SelectedTool, ToolRunModel.RepoPath, ToolRunModel.Branch);
            else
                result = CodeAnalysisServiceClient.GetResult(ToolRunModel.GateThreshold, ToolRunModel.SelectedTool, ToolRunModel.RepoPath, ToolRunModel.Branch);
            UpdateResult(result);
            Navigate.Invoke(ViewPages.Results);

        }
    }
}
