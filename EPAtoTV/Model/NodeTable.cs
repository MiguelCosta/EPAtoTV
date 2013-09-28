using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {
    public class NodeTable {

        public List<NodeTableLine> Lines { get; set; }

        public void AddLine(System.Text.RegularExpressions.Match match) {
            if(Lines == null) Lines = new List<NodeTableLine>();
            this.Lines.Add(new NodeTableLine(match));
        }

    }
}
