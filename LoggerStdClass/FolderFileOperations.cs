using System;
using System.IO;

namespace LoggerStdClass
{
    public static class FolderFileOperations
    {
        // Get project root folder dynamically
        private static string GetProjectRoot()
        {
            // Current directory is usually bin\Debug\netX
            string dir = AppDomain.CurrentDomain.BaseDirectory;

            // Go up 3 levels to reach project root
            string projectRoot = Path.GetFullPath(Path.Combine(dir, @"..\..\.."));
            return projectRoot;
        }

        public static void CreateFolder()
        {
            string folderName = "Logs";
            string path = Path.Combine(GetProjectRoot(), folderName);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static string GetLogFilePath()
        {
            CreateFolder();

            string fileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
            string filePath = Path.Combine(GetProjectRoot(), "Logs", fileName);

            if (!File.Exists(filePath))
            {
                using (var fs = File.Create(filePath))
                {
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes(
                        "Log file created on " + DateTime.Now + Environment.NewLine
                    );
                    fs.Write(info, 0, info.Length);
                }
            }

            return filePath;
        }
    }
}
