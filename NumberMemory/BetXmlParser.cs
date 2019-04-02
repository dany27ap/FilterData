using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NumberMemory {
    class BetXmlParser {
        private String filename;

        public BetXmlParser(String filename) {
            this.filename = filename;
        }

        public BetTableEntry[] readTableEntries() {
            List<BetTableEntry> table = new List<BetTableEntry>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode tbody = doc.GetElementsByTagName("tbody")[0];
            XmlNodeList rows = tbody.SelectNodes("tr");

            foreach(XmlNode row in rows) {
                XmlNodeList data = row.SelectNodes("td");
                if(data.Count == 3) {
                    int nonce = int.Parse(data[0].InnerText);
                    int winnerNo = int.Parse(data[1].InnerText);
                    int pot = int.Parse(data[2].InnerText);
                    BetTableEntry temp = new BetTableEntry(nonce, winnerNo, pot);
                    table.Add(temp);
                } else {
                    Console.Error.WriteLine("Invalid data length on row: " + row.InnerXml);
                }

            }

            return table.ToArray();
        }
    }
}
