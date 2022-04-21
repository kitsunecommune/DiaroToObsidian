using System;
using System.Collections.Generic;

namespace DiaroToObsidian.Models
{
    public class ObsidianData
    {
        public string UniqueID { get; set; } //required
        public string Title { get; set; } //required
        public DateTime Date { get; set; } //very much wanted         
        public string Text { get; set; } //Templates, Entries
        public string Folder { get; set; }
        public List<string> Tags { get; set; }
        public string Mood { get; set; }
    }
}
