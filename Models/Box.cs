using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Box(int id, Player player, Hand firstHand, Hand secondHand)
    {
        public int ID { get; private set; } = id;
        public Player Player { get; private set; } = player;
        public Hand FirstHand { get; private set; } = firstHand;
        public Hand SecondHand { get; private set; } = secondHand;
    }
}
