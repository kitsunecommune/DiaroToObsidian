using System.Collections.Generic;
using System.Xml.Serialization;

namespace DiaroToObsidian.Models
{
    public class DiaroTable
    {
        [XmlAttribute("name")]
        public string TableName { get; set; }
        [XmlElement("r")]
        public List<DiaroEntry> Entries { get; set; }
    }
}
