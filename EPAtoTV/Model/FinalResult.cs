using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {
    public class FinalResult {

        private NodeTable _nodeTable;
        private LinkResult _linkResult;
        public List<FinalResultLine> Lines;

        public FinalResult(NodeTable nodeTable, LinkResult linkResult) {
            _nodeTable = nodeTable;
            _linkResult = linkResult;
            ProcessTable();
        }

        private void ProcessTable() {
            Lines = new List<FinalResultLine>();
            NodeTableLine nTmp;
            LinkResultLine lTmp;

            foreach(NodeTableLine lineNode in _nodeTable.Lines) {
                nTmp = lineNode;
                lTmp = _linkResult.Lines.First(l => l.IDNumber == lineNode.IDNumber);
                Lines.Add(new FinalResultLine(nTmp, lTmp));
            }
        }
    }
}
