using System.Collections.Generic;

namespace DiaroToObsidian.Models
{
    public class DiaroTables
    {
        public List<DiaroEntry> Folders { get; set; }
        public List<DiaroEntry> Tags { get; set; }
        public List<DiaroEntry> Moods { get; set; }
        public List<DiaroEntry> Entries { get; set; }
        public List<DiaroEntry> Templates { get; set; }
    }
}
