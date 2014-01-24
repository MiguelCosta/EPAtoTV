using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Model {
    public class Pipes {

        public List<PipesLine> Lines { get; set; }

        public void AddLine(System.Text.RegularExpressions.Match match) {
            if(Lines == null) Lines = new List<PipesLine>();
            this.Lines.Add(new PipesLine(match));
        }

        public PipesLine GetLines(string reg_id) {
            return this.Lines.Where(x => x.ID == reg_id).FirstOrDefault(); 
        }

    }
}
