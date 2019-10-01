using Models.AnalysisReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Controllers.SimianAnalysisService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISimianAnalysisService" in both code and config file together.
    [ServiceContract]
    public interface ISimianAnalysisService
    {
  
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/InvokeTool/{userName}/{path}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool InvokeTool(string userName, string path);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ParseReport", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<AnalysisReport> ParseReport(string userName, string path, string branch);

    }
}
