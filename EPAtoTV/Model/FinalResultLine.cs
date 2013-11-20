using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {

    public class FinalResultLine {

        private NodeTableLine _node;
        private LinkResultLine _link;

        public FinalResultLine(NodeTableLine nodeTableLine, LinkResultLine linkResultLine) {
            _node = nodeTableLine;
            _link = linkResultLine;
        }

        public int NET_SUBRAA { get { return _node.IDNumber; } }
        public int NET_NODE_BEGIN { get { return _node.StartNodeNumber; } }
        public int NET_NODE_END { get { return _node.EndNodeNumber; } }
        public double NET_LENGTH { get { return _node.Length; } }
        public double NET_Q { get { return _link.Flow; } }
        public double NET_DCOM { get { return _node.Diameter + 10; } }
        public double NET_DINT { get { return _node.Diameter; } }
        public double NET_K { get; set; }
        public double NET_P { get; set; }
        public double NET_D { get { return 0.00000101; } }

    }
}
