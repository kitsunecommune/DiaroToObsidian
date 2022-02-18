using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaroToObsidian.Models
{
    class DiaroTables
    {
        public List<DiaroEntry> Folders { get; set; }
        public List<DiaroEntry> Tags { get; set; }
        public List<DiaroEntry> Moods { get; set; }
        public List<DiaroEntry> Entries { get; set; }
        public List<DiaroEntry> Templates { get; set; }
    }
}
