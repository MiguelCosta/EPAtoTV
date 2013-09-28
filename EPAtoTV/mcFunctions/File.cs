using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace EPAtoTV.mcFunctions {
    static public class File {

        static public System.IO.FileInfo OpenFileTxt() {
            System.IO.FileInfo f = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = ".txt";
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = openFileDialog1.ShowDialog();

            if(result == true) f = new System.IO.FileInfo(openFileDialog1.FileName);

            return f;
        }

    }
}
