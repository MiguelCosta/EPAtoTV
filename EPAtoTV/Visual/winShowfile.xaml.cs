using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EPAtoTV.Visual {
    /// <summary>
    /// Interaction logic for winShowfile.xaml
    /// </summary>
    public partial class winShowfile :Window {
        public winShowfile() {
            InitializeComponent();
            string content = "";

            txtFileContent.Document.Blocks.Clear();
            if(EPAtoTV.Controller.Info.File2Analyse.Exists) {
                content = System.IO.File.ReadAllText(EPAtoTV.Controller.Info.File2Analyse.FullName);
                txtFileContent.AppendText(content);
            } else {
                throw new Exception("File empty");
            }
        }
    }

}
