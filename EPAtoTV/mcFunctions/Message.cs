using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAtoTV.mcFunctions {
    static public class Message {

        static public void ShowMessageError(Exception ex) {
            StringBuilder msg = new StringBuilder("");
            msg.AppendLine("Message: " + ex.Message);
            msg.AppendLine("\n\nSource: " + ex.Source);
            msg.AppendLine("\n\nTrace: " + ex.StackTrace.ToString());

            System.Windows.MessageBox.Show(msg.ToString(), 
                                            "ERRO", 
                                            System.Windows.MessageBoxButton.OK, 
                                            System.Windows.MessageBoxImage.Error);
        }


    }
}
