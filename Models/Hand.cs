using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Hand
    {
        public List<Card> Cards { get; private set; }
        public int Bet { get; set; }

        public bool IsSplit { get; set; }
    }
}
