using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EPAtoTV.Model {
    public class LinkResultLine {

        public LinkResultLine(System.Text.RegularExpressions.Match match) {
            this.ID = match.Groups["ID"].ToString();
            this.Flow = double.Parse(match.Groups["Flow"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            this.VelocityUnit = double.Parse(match.Groups["VelocityUnit"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            this.Headloss = double.Parse(match.Groups["Headloss"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            this.Status = match.Groups["Status"].ToString();
        }

        public string ID { get; set; }
        public int IDNumber {
            get {
                return int.Parse(Regex.Match(this.ID, @"\d+").Value);
            }
        }
        public double Flow { get; set; }
        public double VelocityUnit { get; set; }
        public double Headloss { get; set; }
        public string Status { get; set; }
    }
}
