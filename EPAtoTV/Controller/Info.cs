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

        /// <summary>
        /// Ficheiro que irá servir de input auxiliar para a análise
        /// </summary>
        static public System.IO.FileInfo File2AnalyseAux = null;

        #region Log

        public delegate void LogEventHandler();
        public static event LogEventHandler LogChanged;

        static private StringBuilder _log = new StringBuilder();
        static public String Log { get { return _log.ToString(); } }
        static public void LogAdd(string l) {
            _log.AppendLine("\u2022 " + DateTime.Now.ToString() + " --> " + l);
            LogChanged();
        }

        #endregion

        /// <summary>
        /// Array que contêm as palavras que é para igonrar caso os nodos contenham
        /// </summary>
        static public List<string> IgnoreLine = new List<string>() { "vs" };

        /// <summary>
        /// Indica se é uma linha que é para ignorar ou não
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static public bool IsIgnoreLine(string s) {
            return IgnoreLine.Any(x => s.Contains(x));
        }
    }
}
