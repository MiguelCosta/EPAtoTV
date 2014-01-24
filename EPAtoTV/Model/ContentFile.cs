using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {
    public class ContentFile {

        public NodeTable NodeTable { get; set; }
        public LinkResult LinkResults { get; set; }
        public Pipes Pipes { get; set; }
        public FinalResult FinalResult { get; set; }

        public void AddReservatory(int point) {
            FinalResultLine line = new FinalResultLine( );
            line.NET_SUBRAA = 0;
            line.NET_NODE_BEGIN = point;
            line.NET_NODE_END = point;
            FinalResult.Lines.Add(line);
        }

    }
}
