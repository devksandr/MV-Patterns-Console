namespace MVC
{
    public class AddItemEventArgs : EventArgs
    {
        public string Name { get; }
        public int Count { get; }

        public AddItemEventArgs(string name, int count)
        {
            (Name, Count) = (name, count);
        }
    }
}
