using DiaroToObsidian.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DiaroToObsidian.FileOperators
{
    public class DiaroBackupReader
    {
        private DiaroStructure _resultingMessage;

        public DiaroStructure ReadDiaroXMLIn(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DiaroStructure));

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);
            using (var file = new StreamReader(fileName))
            {
                _resultingMessage = (DiaroStructure)serializer.Deserialize(file);
            }

            return _resultingMessage;
        }
    }
}
