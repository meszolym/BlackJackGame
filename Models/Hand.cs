using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Hand(List<Card> cards)
    {
        public List<Card> Cards { get; private set; } = cards;
        public int Bet { get; set; }
        public bool FromSplit { get; set; }
    }
}
