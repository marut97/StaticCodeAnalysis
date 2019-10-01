using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisClient.ViewModels;

namespace StaticCodeAnalysisClient.Models
{
    public class RepositoryDetailsModel : ViewModelBase
    {

        private string colour;
        public string Colour
        {
            get { return colour; }
            set
            {
                colour = value;
                NotifyPropertyChanged();
            }
        }

        private string repository;
        public string Repository
        {
            get { return repository; }
            set
            {
                repository = value;
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

        private string dateTime;
        public string DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                NotifyPropertyChanged();
            }
        }

        private string tool;
        public string Tool
        {
            get { return tool; }
            set
            {
                tool = value;
                NotifyPropertyChanged();
            }
        }

        private string errors;
        public string Errors
        {
            get { return errors; }
            set
            {
                errors = value;
                NotifyPropertyChanged();
            }
        }
    }
}
