using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrape_getfpv_com
{
    class FindFile
    {
        public bool LookingFileAllDirectories(string folderPath, string folderName)
        {
            string[] allFoundFiles = Directory.GetFiles(Environment.CurrentDirectory, folderName, SearchOption.AllDirectories);
            
                if (allFoundFiles.Count() > 0)
                {
                    String findString = allFoundFiles[0];
                    findString = findString.Replace("\\", "/");
                    File.Copy(allFoundFiles[0], folderPath + "\\" + folderName);
                    Console.WriteLine("have file: " + folderPath + "/" + folderName);
                    return true;
                }
                

                else
                {
                    Console.WriteLine("NO file: " + folderPath + "/" + folderName);
                }
            
            return false;
        }
    }
}
