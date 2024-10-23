using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game(Hand dealerHand, List<Box> boxes)
    {
        public Hand DealerHand { get; private set; } = dealerHand;
        public List<Box> Boxes { get; private set; } = boxes;
    }
}
