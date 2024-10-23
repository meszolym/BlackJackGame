using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Logic
{
    public class MovesLogic(IValueLogic valueLogic)
    {
        private readonly IValueLogic _valueLogic = valueLogic;

        public PossibleActions GetPossibleActions(Hand hand)
        {
            var actions = new PossibleActions();

            var handValue =  _valueLogic.GetValue(hand);

            //no action on bust hands
            if (handValue.Value >= 21) return actions;

            //can hit on any hand that is not bust
            actions.CanHit = true;

            if (hand.Cards.Count == 2)
            {
                //no action on split aces (you get a card when you split aces, no more)
                if (hand.Cards[0].Face == CardFace.Ace && hand.FromSplit) return actions;

                //can double any 2 cards (even after splitting)
                actions.CanDouble = true;

                if (handValue.IsPair && !hand.FromSplit)
                {
                    //can split any pair, defined by the face of the cards (no resplits!)
                    actions.CanSplit = true;
                }
            }

            return actions;

        }

        public void Hit(Hand hand, Shoe shoe)
        {
            if (!GetPossibleActions(hand).CanHit) throw new ArgumentOutOfRangeException(nameof(hand), "Move not possible");

            hand.Cards.Add(shoe.CardQueue.Dequeue());
        }

        public void Double(Hand hand, Shoe shoe)
        {
            if (!GetPossibleActions(hand).CanDouble) throw new ArgumentOutOfRangeException(nameof(hand), "Move not possible");

            hand.Bet *= 2;
            hand.Cards.Add(shoe.CardQueue.Dequeue());
        }

        public void Split(Box box, Shoe shoe)
        {
            if (!GetPossibleActions(box.FirstHand).CanSplit) throw new ArgumentOutOfRangeException(nameof(box), "Move not possible");

            box.SecondHand.Cards.Add(box.FirstHand.Cards[1]);
            box.FirstHand.Cards.RemoveAt(1);
            box.FirstHand.Cards.Add(shoe.CardQueue.Dequeue());

            box.FirstHand.FromSplit = true;
            box.SecondHand.FromSplit = true;

            //after playing the first hand, the second hand has to be hit before playing!
        }
    }
}
