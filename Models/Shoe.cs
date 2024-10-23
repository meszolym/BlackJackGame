using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Shoe(int numberOfDecks, Card[] cards, Queue<Card> cardQueue, int markerCardBasePct, int markerCardVariance)
    {
        public int NumberOfDecks { get; private set; } = numberOfDecks;
        public Card[] Cards { get; private set; } = cards;
        public Queue<Card> CardQueue { get; set; } = cardQueue;
        public int MarkerCardLocation { get; set; }
        public double MarkerCardBasePct { get; set; } = markerCardBasePct;
        public int MarkerCardVariance { get; set; } = markerCardVariance;
    }
}
