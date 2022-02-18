using DiaroToObsidian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaroToObsidian
{
    public class Converter
    {


        public Dictionary<string, List<string>> ConvertListToTablesDict(List<string> lines)
        {
            var tables = new Dictionary<string, List<string>>();
            var currentTable = new List<string>();
            foreach (var line in lines)
            {
                if (line.Contains("table name"))
                {
                    currentTable = new List<string>();
                }
                else if (line.Contains("</table"))
                {
                    tables.Add(currentTable.FirstOrDefault(), currentTable);
                }
            }

            return tables;
        }

        public DiaroTables ConvertTableDictToClass(Dictionary<string, List<string>> dict)
        {
            var temp = new DiaroTables();
            return temp;
        }
    }
}
