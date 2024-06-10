namespace MVC.Models
{
    public class OrderModel
    {
        private Dictionary<string, int> _items = new Dictionary<string, int>();

        public OrderModel()
        {
            // Init: data mock
            AddNewItem("Phone");
            AddItemCount("Phone", 15);

            AddNewItem("PC");
            AddItemCount("PC", 10);

            AddNewItem("Console");
            AddItemCount("Console", 5);
        }

        public void AddNewItem(string? itemName)
        {
            if(string.IsNullOrEmpty(itemName))
            {
                throw new ArgumentNullException("Item name is null");
            }
            if (_items.ContainsKey(itemName))
            {
                throw new ArgumentException($"Already has item with name = {itemName}");
            }

            _items.Add(itemName, 0);
        }

        public void AddItemCount(string? itemName, int count)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                throw new ArgumentNullException("Item name is null");
            }
            if (!_items.ContainsKey(itemName))
            {
                throw new ArgumentException($"No item with name = {itemName}");
            }

            _items[itemName] += count;
        }

        public List<string> GetItmesList() 
            => _items
            .Select(ip => ip.Key)
            .ToList();

        public Dictionary<string, int> GetAllItems() 
            => _items;
    }
}
