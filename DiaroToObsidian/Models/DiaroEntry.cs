using System.Collections.Generic;
using System.Xml.Serialization;

namespace DiaroToObsidian.Models
{
    [XmlRoot("r")]
    public class DiaroEntry
    {
        [XmlElement("uid")]
        public string UniqueID { get; set; } //required
        [XmlElement("title")]
        public string Title { get; set; } //required
        [XmlElement("color")]
        public string Color { get; set; }//folders, moods
        [XmlElement("pattern")]
        public string Pattern { get; set; }////folders
        [XmlElement("icon")]
        public string Icon { get; set; }//moods
        [XmlElement("weight")]
        public string Weight { get; set; }//moods
        [XmlElement("name")]
        public string Name { get; set; }//Templates
        [XmlElement("date")]
        public string Date { get; set; } //very much wanted         
        [XmlElement("text")]
        public string Text { get; set; } //Templates, Entries
        [XmlElement("folder_uid")]
        public string FolderUID { get; set; }
        [XmlElement("tags")]
        public string Tags { get; set; }
        [XmlElement("mood")]
        public string Mood { get; set; }
        [XmlElement("date_created")]
        public string DateCreated { get; set; }
        //tz_offset
        //location_uid
        //primary_photo_uid
        //weather_temperature
        //weather_icon
        //weather_description
    }
}
