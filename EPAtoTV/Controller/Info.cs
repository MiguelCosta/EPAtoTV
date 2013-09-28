using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.Controller {
    static public class Info {

        /// <summary>
        /// Ficheiro que irá servir de input para a análise
        /// </summary>
        static public System.IO.FileInfo File2Analyse = null;

        #region Log

        public delegate void LogEventHandler();
        public static event LogEventHandler LogChanged;

        static private StringBuilder _log = new StringBuilder();
        static public String Log { get { return _log.ToString(); } }
        static public void LogAdd(string l) {
            _log.AppendLine("\u2022 "+ DateTime.Now.ToString() +" --> " + l);
            LogChanged();
        }

        #endregion
    }
}
