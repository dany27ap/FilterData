using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace NumberMemory {
    class Program {

        private static string tableFilename = "bets.bin";

        public static void Main(string[] args) {

            if (args.Length == 1) {
                if (File.Exists(args[0])) {

                    BetTable betTable = null;

                    if (File.Exists(tableFilename)) {
                        FileStream fileStream = new FileStream(tableFilename, FileMode.Open, FileAccess.Read);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();

                        betTable = (BetTable)binaryFormatter.Deserialize(fileStream);
                        fileStream.Close();                        
                    } else {
                        betTable = new BetTable();
                    }

                    BetXmlParser parser = new BetXmlParser(args[0]);
                    BetTableEntry[] entries = parser.readTableEntries();
                   
                    foreach (BetTableEntry var in entries) {
                        betTable.add(var);
                    }

                    //Serialization
                    {
                        if (File.Exists(tableFilename)) {
                            File.Copy(tableFilename, "bets_" + RandomString.getUnuiqueString(20) + ".tmp");
                        }
                        FileStream fileStream = new FileStream(tableFilename, FileMode.OpenOrCreate, FileAccess.Write);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(fileStream, betTable);
                        fileStream.Close();
                    }

                    File.Delete(args[0]);

                } else {
                    Console.Error.WriteLine("Invalid filename!");
                    Environment.Exit(2);
                }

            } else {
                Console.Error.WriteLine("Invalid arguments!");
                Environment.Exit(1);
            }
        }
    }
}
