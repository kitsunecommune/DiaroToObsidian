using System.Collections.Generic;
using System.Xml.Serialization;

namespace DiaroToObsidian.Models
{
    [XmlRoot("data")]
    public class DiaroStructure
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("table")]
        public List<DiaroTable> Tables { get; set; }
    }
}
