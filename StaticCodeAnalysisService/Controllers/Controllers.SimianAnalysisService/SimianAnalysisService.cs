using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contracts.ToolExecuter;
using Models.AnalysisReport;
using PVS.ToolExecuterLib;
using Contracts.ReportParser;

namespace Controllers.SimianAnalysisService
{
    public class SimianAnalysisService:ISimianAnalysisService
    {

        public bool InvokeTool(string userName, string path)
        {
            IToolExecuter toolExecuter = new PVSToolExecuter();
            return toolExecuter.ExecuteTool(userName, path);
        }

        public List<AnalysisReport> ParseReport(string userName, string path, string branch)
        {
            IReportParser parser = new Simian.ReportParserLib.SimianReportParser();
            return parser.ParseReport(userName, path, branch);
        }
    }
}