using DiaroToObsidian.FileOperators;
using DiaroToObsidian.Logic;

namespace DiaroToObsidian
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "E:/NPCNotesBackup/Diaro/Diaro_auto_20220215/DiaroBackup.xml";

            var reader = new DiaroBackupReader();
            var converter = new Converter();
            var creator = new ObsidianFileCreator(); //eventually will be used for creating files for obsidian

            var diaroData = reader.ReadDiaroXMLIn(fileName);
            var obsidianData = converter.DiaroDataToObsidianData(diaroData);
            creator.CreateAll(obsidianData);
        }
    }
}
