using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Models
{
    public static class LogTxt
    {
        public static string LogPath;
        public static void Write(string message)
        {
            using (StreamWriter sw = new StreamWriter(LogPath, true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
