using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.mcFunctions {
    public static class Format {

        public static string Dbl2Str_ENG(double value) {
            return value.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-GB"));
        }

    }
}
