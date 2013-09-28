using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {
    public class NodeTableLine {

        public NodeTableLine(System.Text.RegularExpressions.Match match) {
            this.ID = match.Groups["ID"].ToString();
            this.StartNode = match.Groups["StartNode"].ToString();
            this.EndNode = match.Groups["EndNode"].ToString();
            this.Length = double.Parse(match.Groups["Length"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            this.Diameter = double.Parse(match.Groups["Diameter"].ToString());
        }

        public string ID { get; set; }
        public string StartNode { get; set; }
        public string EndNode { get; set; }
        public double Length { get; set; }
        public double Diameter { get; set; }

    }
}
