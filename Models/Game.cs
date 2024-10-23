using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public Hand DealerHand { get; private set; }
        public List<Box> Boxes { get; private set; }
    }
}
