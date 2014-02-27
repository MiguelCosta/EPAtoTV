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
    public partial class MainWindow : Window {

        Model.ContentFile file;

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
                Controller.Info.File2Analyse = mcFunctions.File.OpenFileTxt("Relatório de simulação");
                Controller.Info.File2AnalyseAux = mcFunctions.File.OpenFileTxt("Ficheiro com NET_K e NET_P");
                if(Controller.Info.File2Analyse.Exists && Controller.Info.File2AnalyseAux.Exists) {
                    Controller.Info.LogAdd("File: " + Controller.Info.File2Analyse.FullName);
                    Controller.Info.LogAdd("File: " + Controller.Info.File2AnalyseAux.FullName);
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

            try {

                string input = "";
                input = mcFunctions.Message.InputMessageText("Simbologia da tubagem", "Insira separado por ponto e vírgula os perfixos da identificação das tubagens:", String.Join(",", Controller.Info.AcceptLine.ToArray()));
                Controller.Info.AcceptLine = input.Split(',').ToList();

                Controller.Info.LogAdd("Read file begin");
                file = Controller.ReadFile.Execute();

                dgrNodeTable.ItemsSource = file.FinalResult.Lines;

            } catch(Exception ex) {
                mcFunctions.Message.ShowMessageError(ex);
            } finally {
                Controller.Info.LogAdd("Read file end");
            }
        }

        #endregion

        private void btnAddInitialPoint_Click(object sender, RoutedEventArgs e) {
            string input = "";
            List<int> points = new List<int>();
            try {

                input = mcFunctions.Message.InputMessageText("Add initial point", "Indique a que pontos liga o reservatório separados por ';'(ponto e vírgula)");
                points = input.Split(';').Select(x => int.Parse(x)).ToList();

                foreach(int p in points) {
                    file.AddReservatory(p);
                }

                dgrNodeTable.ItemsSource = null;
                dgrNodeTable.ItemsSource = file.FinalResult.Lines;

            } catch(Exception ex) {
                mcFunctions.Message.ShowMessageError(ex);
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e) {
            try {
                mcFunctions.File.SaveFileXML(file.FinalResult.ToXML());
            } catch(Exception ex) {
                mcFunctions.Message.ShowMessageError(ex);
            }
        }

    }
}
