namespace Models
{
    public class Player(string name, int balance)
    {
        public Guid Guid { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = name;
        public int Balance { get; set; } = balance;
    }
}
