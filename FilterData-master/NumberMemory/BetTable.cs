using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberMemory {
    [Serializable]
    class BetTable {
        private List<BetTableEntry> entries = new List<BetTableEntry>();

        public void add(BetTableEntry betTableEntry) {
            if(!entries.Contains(betTableEntry)) {
                entries.Add(betTableEntry);
            }
        }
    }
}
