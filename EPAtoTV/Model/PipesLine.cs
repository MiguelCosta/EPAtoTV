using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {
    public class PipesLine {

        public PipesLine(System.Text.RegularExpressions.Match match) {
            this.ID = match.Groups["ID"].ToString();
            this.Roughness = double.Parse(match.Groups["Roughness"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            this.Net_PD = double.Parse(match.Groups["NetPD"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
        }

        public string ID { get; set; }
        public double Roughness { get; set; }
        public double Net_PD { get; set; }

    }
}
