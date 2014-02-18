using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {
    public class FinalResult {

        private NodeTable _nodeTable;
        private LinkResult _linkResult;
        private Pipes _pipesTable;
        private List<FinalResultLine> _lines;

        public List<FinalResultLine> Lines { get { return _lines; } set { _lines = value; } }

        public FinalResult(NodeTable nodeTable, LinkResult linkResult, Pipes pipesTable) {
            _nodeTable = nodeTable;
            _linkResult = linkResult;
            _pipesTable = pipesTable;
            ProcessTable();
        }

        private void ProcessTable() {
            _lines = new List<FinalResultLine>();
            NodeTableLine nTmp;
            LinkResultLine lTmp;
            PipesLine pTmp;

            foreach(NodeTableLine lineNode in _nodeTable.Lines) {
                try {
                    nTmp = lineNode;
                    lTmp = _linkResult.Lines.First(l => l.IDNumber == lineNode.IDNumber);
                    pTmp = _pipesTable.GetLines(lineNode.ID);
                    Lines.Add(new FinalResultLine(nTmp, lTmp, pTmp));
                } catch(Exception) {
                    throw;
                }
            }

            _lines = _lines.OrderBy(x => x.NET_SUBRAA).ToList();
        }

        public string ToXML() {
            string s = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n";
            s += "<SHAPE xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n";
            foreach(FinalResultLine line in Lines) {
                s += line.ToXML();
            }
            s += "</SHAPE>";
            return s;
        }
    }
}
