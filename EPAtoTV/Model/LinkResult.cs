using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {
    public class LinkResult {

        public List<LinkResultLine> Lines { get; set; }

        public void AddLine(System.Text.RegularExpressions.Match match) {
            if(Lines == null) Lines = new List<LinkResultLine>();
            this.Lines.Add(new LinkResultLine(match));
        }
    }
}
