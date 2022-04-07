using DiaroToObsidian.FileOperators;

namespace DiaroToObsidian
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "E:/NPCNotesBackup/Diaro/Diaro_auto_20220215/DiaroBackup.xml";

            var reader = new DiaroBackupReader();
            var creator = new MarkdownFileCreator(); //eventually will be used for creating files for obsidian

            var diaroData = reader.ReadDiaroXMLIn(fileName);


            var temp = "hello";

        }
    }
}
