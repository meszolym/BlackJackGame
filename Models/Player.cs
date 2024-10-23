namespace Models
{
    public class Player(string name, int balance)
    {
        public string Name { get; private set; } = name;
        public int Balance { get; set; } = balance;
    }
}
