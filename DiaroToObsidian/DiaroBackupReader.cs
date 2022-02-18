using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaroToObsidian
{
    public class DiaroBackupReader
    {

        public List<string> ReadDiaroEntryIn(string fileName)
        {
            var lineList = new List<string>();
            using (var file = new StreamReader(fileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    lineList.Add(line);
                }
                file.Close();
            }

            return lineList;
        }
    }
}
