using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberMemory {
    [Serializable]
    class BetTableEntry{
        private int nonce;
        private int winnerNo;
        private int pot;
        private DateTime date;

        public BetTableEntry(int nonce, int winnerNo, int pot) {
            this.nonce = nonce;
            if (winnerNo >= 0 && winnerNo <= 14)
                this.winnerNo = winnerNo;
            else
                throw new InvalidWinnerNumberException();
            this.pot = pot;
            this.date = DateTime.Now;
        }

        public override bool Equals(Object obj) {
            if( (obj == null) || !this.GetType().Equals(obj.GetType()) ) {
                return false;
            } else {
                BetTableEntry p = (BetTableEntry)obj;
                return (this.nonce == p.nonce);
            }
        }

        public string toJson() {
            return "{ \"nonce\":" + this.nonce + ", \"winnerNo\":" + this.winnerNo + ", \"pot\":" + this.pot + ", \"date\":\"" + this.date.ToString() + "\" }";
        }

    }
}
