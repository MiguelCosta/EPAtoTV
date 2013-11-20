using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Controller {
    static public class ReadFile {

        private enum ReadStep {
            None,
            NodeTableRead,
            LinkResultsRead
        }
        static private ReadStep step = ReadStep.None;

        static private string rgNodeTableRead       = @"\s+Link - Node Table:";
        static private string rgNodeTableReadLine   = @"\s+(?<ID>[a-zA-Z0-9\-]+)\s+(?<StartNode>[a-zA-Z0-9]+)\s+(?<EndNode>[a-zA-Z0-9]+)\s+(?<Length>[0-9\.]+)\s+(?<Diameter>[0-9]+)";

        static private string rgLinkResults         = @"\s+Link Results:";
        static private string rgLinkResultsLine     = @"\s+(?<ID>[a-zA-Z0-9\-]+)\s+(?<Flow>[0-9\.]+)\s+(?<VelocityUnit>[0-9\.]+)\s+(?<Headloss>[0-9\.]+)\s+(?<Status>[a-zA-Z0-9\-]+)";

        static private Model.ContentFile fileResult;

        static public Model.ContentFile Execute() {
            List<string> lines = new List<string>();
            lines = System.IO.File.ReadAllLines(Controller.Info.File2Analyse.FullName).ToList();
            int lineNumber = 1;

            fileResult = new Model.ContentFile();

            foreach(string line in lines) {
                ProcessLine(line, lineNumber);
                lineNumber++;
            }

            fileResult.FinalResult = new Model.FinalResult(fileResult.NodeTable, fileResult.LinkResults);

            return fileResult;
        }

        static private void ProcessLine(string s, int lineNumber) {
            switch(step) {
                case ReadStep.None:
                    if(System.Text.RegularExpressions.Regex.IsMatch(s, rgNodeTableRead)) {
                        Controller.Info.LogAdd("Node Table Read found in L" + lineNumber + ": " + s);
                        fileResult.NodeTable = new Model.NodeTable();
                        step = ReadStep.NodeTableRead;
                    }
                    break;
                case ReadStep.NodeTableRead:
                    if(System.Text.RegularExpressions.Regex.IsMatch(s, rgLinkResults)) {
                        Controller.Info.LogAdd("Link Results found in L" + lineNumber + ": " + s);
                        fileResult.LinkResults = new Model.LinkResult();
                        step = ReadStep.LinkResultsRead;
                    }
                    if(System.Text.RegularExpressions.Regex.IsMatch(s, rgNodeTableReadLine) && Controller.Info.IsIgnoreLine(s) == false) {
                        Controller.Info.LogAdd("Node Table Read Line found in L" + lineNumber + ": " + s);
                        fileResult.NodeTable.AddLine(System.Text.RegularExpressions.Regex.Match(s, rgNodeTableReadLine));
                    }
                    break;
                case ReadStep.LinkResultsRead:
                    if(System.Text.RegularExpressions.Regex.IsMatch(s, rgLinkResultsLine) && Controller.Info.IsIgnoreLine(s) == false) {
                        Controller.Info.LogAdd("Link Result Read Line found in L" + lineNumber + ": " + s);
                        fileResult.LinkResults.AddLine(System.Text.RegularExpressions.Regex.Match(s, rgLinkResultsLine));
                    }
                    break;

                default:
                    break;
            }
        }


    }
}
