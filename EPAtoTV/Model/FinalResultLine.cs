using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {

    public class FinalResultLine {

        private NodeTableLine _node;
        private LinkResultLine _link;

        private int _net_subraa;
        private int _net_node_begin;
        private int _net_node_end;

        public FinalResultLine() {
        }

        public FinalResultLine(NodeTableLine nodeTableLine, LinkResultLine linkResultLine, PipesLine pipeLine) {
            _node = nodeTableLine;
            _link = linkResultLine;
            _net_subraa = _node.IDNumber;
            _net_node_begin = _node.StartNodeNumber > _node.EndNodeNumber ? _node.EndNodeNumber : _node.StartNodeNumber;
            _net_node_end = _node.EndNodeNumber < _node.StartNodeNumber ? _node.StartNodeNumber : _node.EndNodeNumber;
            if (pipeLine != null) {
                this.NET_K = pipeLine.Roughness;
                this.NET_P = pipeLine.Net_PD;
            }
        }

        public int NET_SUBRAA { get { return _net_subraa; } set { _net_subraa = value; } }
        public int NET_NODE_BEGIN {
            get {
                return _net_node_begin;
            }
            set {
                _net_node_begin = value;
            }
        }
        public int NET_NODE_END {
            get {
                return _net_node_end;
            }
            set {
                _net_node_end = value;
            }
        }
        public double NET_LENGTH { get { return _node == null ? 0 : _node.Length; } }
        public double NET_Q {
            get {
                return _link == null ? 0 : Math.Abs(_link.Flow);
            }
        }
        public double NET_DCOM { get { return _node == null ? 0 : _node.Diameter + 10; } }
        public double NET_DINT { get { return _node == null ? 0 : _node.Diameter; } }
        public double NET_K { get; set; }
        public double NET_P { get; set; }
        public double NET_D { get { return _node == null ? 0 : 0.00000101; } }

        public string ToXML() {
            string s = "<LINK>\n";
            s += "  <NET_SUBRAA>" + this.NET_SUBRAA + "</NET_SUBRAA>\n";
            s += "  <NET_NODE_BEGIN>" + this.NET_NODE_BEGIN + "</NET_NODE_BEGIN>\n";
            s += "  <NET_NODE_END>" + this.NET_NODE_END + "</NET_NODE_END>\n";
            s += "  <NET_LENGTH>" + mcFunctions.Format.Dbl2Str_ENG(this.NET_LENGTH) + "</NET_LENGTH>\n";
            s += "  <NET_Q>" + mcFunctions.Format.Dbl2Str_ENG(this.NET_Q) + "</NET_Q>\n";
            s += "  <NET_DCOM>" + mcFunctions.Format.Dbl2Str_ENG(this.NET_DCOM) + "</NET_DCOM>\n";
            s += "  <NET_DINT>" + mcFunctions.Format.Dbl2Str_ENG(this.NET_DINT) + "</NET_DINT>\n";
            s += "  <NET_K>" + mcFunctions.Format.Dbl2Str_ENG(this.NET_K) + "</NET_K>\n";
            s += "  <NET_P>" + mcFunctions.Format.Dbl2Str_ENG(this.NET_P) + "</NET_P>\n";
            s += "  <NET_D>" + mcFunctions.Format.Dbl2Str_ENG(this.NET_D) + "</NET_D>\n";
            s += "</LINK>\n";
            return s;
        }

    }
}
