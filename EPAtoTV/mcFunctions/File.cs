using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace EPAtoTV.mcFunctions {
    static public class File {

        static public System.IO.FileInfo OpenFileTxt(string title = "") {
            System.IO.FileInfo f = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = title;
            openFileDialog1.DefaultExt = ".txt";
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = openFileDialog1.ShowDialog();

            if(result == true) f = new System.IO.FileInfo(openFileDialog1.FileName);

            return f;
        }

        static public void SaveFileXML(string content) {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if(saveFileDialog1.ShowDialog().Value == true) {
                System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName);
                file.Write(content);
                file.Close();
            }
        }

    }
}
