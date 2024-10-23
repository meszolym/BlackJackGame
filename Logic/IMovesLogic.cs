using Models;

namespace Logic;

public interface IMovesLogic
{
    public PossibleActions GetPossibleActions(Hand hand);
    public void Hit(Hand hand, Shoe shoe);
    public void Double(Hand hand, Shoe shoe);
    public void Split(Box box, Shoe shoe);
}