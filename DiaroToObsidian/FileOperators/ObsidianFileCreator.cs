using DiaroToObsidian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaroToObsidian.FileOperators
{
    public class ObsidianFileCreator
    {
        public void CreateAll(List<ObsidianData> data)
        {
            //takes in a file location and the info to populate the file with.
            //May have logic for what type of file it is but I doubt it
            //Should only care about Date, Title, Text, Folder, Tags, maybe mood?
            var dict = new Dictionary<string, List<string>>();
            foreach (var entry in data)
            {
                if (dict.ContainsKey(entry.Title))
                {
                    entry.Title = $"{entry.Title} {entry.Date}";
                }
                var fileLines = CreateFileFormat(entry);
                dict.Add(entry.Title, fileLines);
            }
        }

        private List<string> CreateFileFormat(ObsidianData entry)
        {
            var lines = new List<string>();

            lines.Add("---");
            lines.Add($"tags: {String.Join(", ", entry.Tags)}");
            var date = entry.Date.ToString("yyyy-MM-dd HH-mm");
            lines.Add($"created-date: {date}");
            if (entry.Mood != null) { lines.Add($"mood: {entry.Mood}"); }
            lines.Add($"---{Environment.NewLine}");

            var links = !string.IsNullOrEmpty(entry.Folder) ? "[[{entry.Folder}]]" : "";
            lines.Add($"%% ***Links:*** {links} %%");
            lines.Add($"# {entry.Title}");
            lines.Add(entry.Text);
            //still need to do something with Folder

            //lines.ForEach(line => Console.WriteLine(line));
            return lines;
        }
    }
}
