//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace InfoToBG
{
    class SaveXml
    {
        public static void SaveComputer(object sender, string fileName)
        {
            XmlSerializer sr = new XmlSerializer(sender.GetType());
            TextWriter writer = new StreamWriter(fileName);
            sr.Serialize(writer, sender);
            writer.Close();
        }
    }
}
