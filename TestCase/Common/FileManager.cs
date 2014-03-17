using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class FileManager
    {
        public static void DirectoryCopy(string sourceDirPath, string destDirPath, bool copySubDir = true)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirPath);
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                 "Source directory does not exist or could not be found: "
                 + sourceDirPath);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirPath))
            {
                Directory.CreateDirectory(destDirPath);
            }

            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirPath, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDir)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirPath, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath);
                }
            }
        }

        public static bool CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                FileStream myFs = new FileStream(filePath, FileMode.Create);
                StreamWriter mySw=new StreamWriter(myFs);
                mySw.Write("11");
                myFs.Close();
                return true;
            }
            return false;
        }
    }
}
