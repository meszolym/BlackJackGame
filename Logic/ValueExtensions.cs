using Models;

namespace Logic
{
    public static class ValueExtensions
    {
        /// <summary>
        /// Gets the value of a card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>The value of the card in blackjack. Aces are counted as 1.</returns>
        public static int GetValue(this Card card) => card switch
        {
            { Face: CardFace.King } => 10,
            { Face: CardFace.Jack } => 10,
            { Face: CardFace.Queen } => 10,
            _ => (int)card.Face
        };

        public static HandValue GetValue(this Hand hand)
        {
            int val = 0;
            bool ace = false;
            
            hand.Cards.Iter(card =>
            {
                if (card.Face == CardFace.Ace) ace = true;
                val += card.GetValue();
            });

            bool soft = ace && val <= 11;

            //ace was counted as one in the card evaluation, so we add 10 to the value if possible.
            if (soft) val += 10;

            //blackjack can't be a pair nor soft.
            if (ace && val == 21) return new HandValue(val, true, false, false);

            bool pair = (hand.Cards.Count == 2 && hand.Cards[0].Face == hand.Cards[1].Face && !hand.IsSplit);

            return new HandValue(val, false, pair, soft);
        }
    }
}
