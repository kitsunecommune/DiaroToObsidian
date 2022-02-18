using System.Collections.Generic;

namespace DiaroToObsidian.Models
{
    public class DiaroEntry
    {
        public string UniqueID { get; set; } //required             //appears as uid
        public string Title { get; set; } //required
        public string Color { get; set; }//folders, moods
        public string Pattern { get; set; }////folders
        public string Icon { get; set; }//moods
        public string Weight { get; set; }//moods
        public string Name { get; set; }//Templates
        public string Date { get; set; } //very much wanted         //appears as date_created for Templates
        public string Text { get; set; } //Templates, Entries
        public string FolderUID { get; set; }                       //folder_uid
        public List<string> Tags { get; set; }
        public string Mood { get; set; }
        //tz_offset
        //location_uid
        //primary_photo_uid
        //weather_temperature
        //weather_icon
        //weather_description
    }
}
