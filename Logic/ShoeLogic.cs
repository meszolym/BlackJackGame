using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Logic
{
    public class ShoeLogic
    {
        private Random random;

        public ShoeLogic(Random random)
        {
            this.random = random;
        }

        public void ShuffleShoe(Shoe shoe)
        {
            for (int i = 0; i < shoe.Cards.Length; i++)
            {
                int j = random.Next(i, shoe.Cards.Length);
                (shoe.Cards[i], shoe.Cards[j]) = (shoe.Cards[j], shoe.Cards[i]);
            }

            shoe.MarkerCardLocation = (int)Math.Round(shoe.Cards.Length*shoe.MarkerCardBasePct)+random.Next(-1*shoe.MarkerCardVariance, shoe.MarkerCardVariance);

            shoe.CardQueue = new Queue<Card>(shoe.Cards);
        }
    }
}
