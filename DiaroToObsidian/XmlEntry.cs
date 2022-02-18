using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaroToObsidian
{
    public class XmlEntry
    {
        public string UniqueID { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Folder { get; set; }
        public List<string> Tags { get; set; }
        public int Mood { get; set; }
    }
}
