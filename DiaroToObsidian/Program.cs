namespace DiaroToObsidian
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "E:/NPCNotesBackup/Diaro/Diaro_auto_20220215/DiaroBackup.xml";

            var converter = new Converter();
            var reader = new DiaroBackupReader();

            var lines = reader.ReadDiaroEntryIn(fileName);
            var tables = converter.ConvertListToTablesDict(lines);
        }
    }
}
