using DiaroToObsidian.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiaroToObsidian.FileOperators
{
    public class ObsidianFileCreator
    {
        private string _scaryCharacters = "[<>:\"?*/\\|]";

        public void CreateAll(List<ObsidianData> data, string folderPath)
        {
            //takes in a file location and the info to populate the file with.
            //May have logic for what type of file it is but I doubt it
            //Should only care about Date, Title, Text, Folder, Tags, maybe mood?
            var dict = CreateFileDict(data);

            foreach (var entry in dict)
            {
                CreateFile(entry.Key, entry.Value, folderPath);
            }
        }

        private Dictionary<string, List<string>> CreateFileDict(List<ObsidianData> data)
        {
            var dict = new Dictionary<string, List<string>>();
            var lowerHash = new HashSet<string>();
            foreach (var entry in data)
            {
                var formattedDate = entry.Date.ToString("yyyy-MM-dd HH-mm");
                if (string.IsNullOrWhiteSpace(entry.Title))
                {
                    entry.Title = $"Journal {formattedDate}";
                }
                var lowerTitle = entry.Title.ToLower();
                if (dict.ContainsKey(entry.Title) | lowerHash.Contains(lowerTitle))
                {
                    entry.Title = $"{entry.Title} {formattedDate}";
                }
                var fileLines = CreateFileFormat(entry);

                lowerHash.Add(lowerTitle);
                dict.Add(entry.Title, fileLines);
            }

            return dict;
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

            var links = !string.IsNullOrEmpty(entry.Folder) ? $"[[{entry.Folder}]]" : "";
            lines.Add($"%% ***Links:*** {links} %%");
            //most people would probably want tags and folders reversed, but makes more sense this way for me, might update later
            lines.Add($"# {entry.Title}");
            lines.Add(entry.Text);

            return lines;
        }

        private void CreateFile(string title, List<string> fileLines, string folderPath)
        {
            var modifiedTitle = Regex.Replace(title, _scaryCharacters, " ");
            var fileName = $"{folderPath}/{modifiedTitle}.md";
            try
            {
                if (File.Exists(fileName))
                {
                    Console.Error.WriteLine($"Yooo there's already an existing version of {fileName}, deleting it but be warned I guess?");
                    //probably have some logic here to ask first?
                    File.Delete(fileName);
                    //either that or just tack on the uid and check that and then delete old version if same or something
                }

                using (var sw = File.CreateText(fileName))
                {
                    foreach(var line in fileLines)
                    {
                        sw.WriteLine(line);
                    }
                }
                Console.WriteLine($"Success! Written to {fileName}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create file with name {fileName} with exception {ex} :(");
            }
        }
    }
}
