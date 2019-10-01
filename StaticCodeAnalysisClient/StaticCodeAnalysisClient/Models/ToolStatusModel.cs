using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticCodeAnalysisClient.ViewModels;

namespace StaticCodeAnalysisClient.Models
{
    public class ToolStatusModel : ViewModelBase
    {
        private string statusImage;
        public string StatusImage
        {
            get { return statusImage; }
            set
            {
                statusImage = value;
                NotifyPropertyChanged();
            }
        }

        private string statusMessage;
        public string StatusMessage
        {
            get { return statusMessage; }
            set
            {
                statusMessage = value;
                NotifyPropertyChanged();
            }
        }
    }
}
