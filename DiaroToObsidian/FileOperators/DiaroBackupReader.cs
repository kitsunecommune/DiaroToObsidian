using DiaroToObsidian.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DiaroToObsidian.FileOperators
{
    public class DiaroBackupReader
    {
        private DiaroData _resultingMessage;

        public DiaroData ReadDiaroXMLIn(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DiaroData));

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);
            using (var file = new StreamReader(fileName))
            {
                _resultingMessage = (DiaroData)serializer.Deserialize(file);
            }

            return _resultingMessage;
        }
    }
}
