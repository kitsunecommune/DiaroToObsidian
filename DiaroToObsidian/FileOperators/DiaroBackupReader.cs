using DiaroToObsidian.Models;
using System.Collections.Generic;
using System.IO;

namespace DiaroToObsidian.FileOperators
{
    public class DiaroBackupReader
    {
        //I realize that I could do this same thing with File.ReadAllLines() but eventually...
        //I'd like to do all the assigning in here and I've just temporarily been doing it another dumb way cuz I'm baking
        public List<string> ReadDiaroEntryIn(string fileName)
        {
            var lineList = new List<string>();
            //var tables = new DiaroTables();
            using (var file = new StreamReader(fileName))
            {
                string line;

                DiaroEntry currentEntry = null;
                string currentTable;
                while ((line = file.ReadLine()) != null)
                {
                    if (currentEntry != null)
                    {
                        //if we are still working through a table just continue filling out details based on which one
                        //when we hit the end table we want to set back to null
                    }
                    else
                    {
                        //if we are between tables we want to check which table we've hit and call different things based on it
                        //and maybe data version (for completeness even though I don't think it'll matter?)
                    }
                    lineList.Add(line);
                }
                file.Close();
            }

            return lineList;
        }
    }
}
