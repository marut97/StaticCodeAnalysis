using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisClient.StaticCodeAnalysisService;
using StaticCodeAnalysisClient.ViewModels;

namespace StaticCodeAnalysisClient.Models
{
    public class ToolRunModel : ViewModelBase
    {
        private ObservableCollection<GatingResult> recentRepos;
        public ObservableCollection<GatingResult> RecentRepos
        {
            get { return recentRepos;}
            set
            {
                recentRepos = value;
                NotifyPropertyChanged();
            }
        }

        private Dictionary<Tools, string> allTools;
        public Dictionary<Tools, string> AllTools
        {
            get { return allTools; }
            set
            {
                allTools = value; 
                NotifyPropertyChanged();
            }
        }

        private Tools selectedTool;
        public Tools SelectedTool
        {
            get { return selectedTool; }
            set
            {
                selectedTool = value;
                NotifyPropertyChanged();
            }
        }

        private string repoPath;
        public string RepoPath
        {
            get { return repoPath; }
            set
            {
                repoPath = value;
                NotifyPropertyChanged();
            }
        }

        private string branch;
        public string Branch
        {
            get { return branch; }
            set
            {
                branch = value;
                NotifyPropertyChanged();
            }
        }

        private bool repoType;
        public bool RepoType
        {
            get { return repoType; }
            set
            {
                repoType = value;
                NotifyPropertyChanged();
            }
        }

        private bool gateType;
        public bool GateType
        {
            get { return gateType; }
            set
            {
                gateType = value;
                NotifyPropertyChanged();
            }
        }

        private int gateThreshold;

        public int GateThreshold
        {
            get { return gateThreshold; }
            set
            {
                gateThreshold = value;
                NotifyPropertyChanged();
            }
        }

    }
}
