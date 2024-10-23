using Models;

namespace Logic
{
    public class ValueLogic : IValueLogic
    {
        /// <summary>
        /// Gets the value of a card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>The value of the card in blackjack. Aces are counted as 1.</returns>
        public int GetValue(Card card) => card switch
        {
            { Face: CardFace.King } => 10,
            { Face: CardFace.Jack } => 10,
            { Face: CardFace.Queen } => 10,
            _ => (int)card.Face
        };

        public HandValue GetValue(Hand hand)
        {
            var handValue = new HandValue();
            
            bool containsAce = false;
            hand.Cards.Iter(card =>
            {
                if (card.Face == CardFace.Ace) containsAce = true;
                handValue.Value += GetValue(card);
            });

            handValue.IsSoft = containsAce && handValue.Value <= 11;

            //ace was counted as one in the card evaluation, so we add 10 to the value if possible.
            if (handValue.IsSoft) handValue.Value += 10;

            //blackjack can't be a pair nor soft.
            if (containsAce && handValue.Value == 21)
            {
                handValue.IsBlackJack = true;
                handValue.IsSoft = false;
                return handValue;
            }

            //pair is only possible with two cards of the same face, and not if the hand was split already.
            handValue.IsPair = (hand.Cards.Count == 2 && hand.Cards[0].Face == hand.Cards[1].Face && !hand.FromSplit);

            return handValue;
        }
    }
}
