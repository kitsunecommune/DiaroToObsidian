using DiaroToObsidian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaroToObsidian.Logic
{
    public class Converter
    {
        Dictionary<string, DiaroEntry> _folders;
        Dictionary<string, string> _tags;
        Dictionary<string, DiaroEntry> _moods;
        List<DiaroEntry> _entries;

        public List<ObsidianData> DiaroDataToObsidianData(DiaroData diaroData)
        {
            foreach(var table in diaroData.Tables)
            {
                switch (table.TableName)
                {
                    case "diaro_folders":
                        _folders = table.Entries.ToDictionary(x => x.UniqueID, x => x);
                        break;
                    case "diaro_tags":
                        _tags = table.Entries.ToDictionary(x => x.UniqueID, x => x.Title);
                        break;
                    case "diaro_moods":
                        _moods = table.Entries.ToDictionary(x => x.UniqueID, x => x);
                        break;
                    case "diaro_entries":
                        _entries = table.Entries;
                        break;
                    case "diaro_templates": //not doing anything with these for now...
                    default:
                        break;
                }
            }
            var obsidianEntries = new List<ObsidianData>();
            foreach(var entry in _entries)
            {
                var temp = entry.Tags.Split(',',StringSplitOptions.RemoveEmptyEntries).ToList();
                var tags = temp.Select(x => _tags[x]);
                var mood = int.TryParse(entry.Mood, out int moodInt) ? moodInt : 0;

                var data = new ObsidianData()
                {
                    UniqueID = entry.UniqueID,
                    Date = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(entry.Date)).DateTime,
                    Folder = !string.IsNullOrWhiteSpace(entry.FolderUID) ? _folders[entry.FolderUID].Title : null,
                    Mood = mood > 0 ? _moods[entry.Mood].Title : null,
                    Tags = tags.ToList(),
                    Text = entry.Text,
                    Title = entry.Title
                };
                obsidianEntries.Add(data);
            }

            return obsidianEntries;
        }
    }
}
