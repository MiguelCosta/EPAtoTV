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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPAtoTV {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window {
        public MainWindow() {
            InitializeComponent();

            Controller.Info.LogChanged += Info_LogChanged;
        }

        void Info_LogChanged() {
            txtLog.Text = Controller.Info.Log;
            txtLog.ScrollToEnd();
        }

        #region Menu

        private void btnOpenFile_Click(object sender, RoutedEventArgs e) {
            try {
                Controller.Info.File2Analyse = mcFunctions.File.OpenFileTxt();
                if(Controller.Info.File2Analyse.Exists) {
                    Controller.Info.LogAdd("File: " + Controller.Info.File2Analyse.FullName);
                } else {
                    Controller.Info.LogAdd("File not found");
                }
            } catch(Exception ex) {
                mcFunctions.Message.ShowMessageError(ex);
            }
        }

        private void btnShowFile_Click(object sender, RoutedEventArgs e) {
            try {
                if(Controller.Info.File2Analyse.Exists) {
                    Visual.winShowfile f = new Visual.winShowfile();
                    f.ShowDialog();
                }
            } catch(Exception ex) {
                mcFunctions.Message.ShowMessageError(ex);
            }
        }

        private void btnReadFile_Click(object sender, RoutedEventArgs e) {
            Model.ContentFile file;
            
            try {
                Controller.Info.LogAdd("Read file begin");
                file = Controller.ReadFile.Execute();

                dgrNodeTable.ItemsSource = file.NodeTable.Lines;

            } catch(Exception ex) {
                mcFunctions.Message.ShowMessageError(ex);
            } finally {
                Controller.Info.LogAdd("Read file end");
            }
        }

        #endregion





    }
}
