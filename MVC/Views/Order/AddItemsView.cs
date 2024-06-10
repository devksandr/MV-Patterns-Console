using System.Text;
using System.Text.RegularExpressions;

namespace MVC.Views.Order
{
    public class AddItemsView : IView
    {
        private const string ADD_ITEM_PATTERN = "^1\\s(\\d+)\\s(\\d+)$";
        private const int ADD_ITEM_MAX_COUNT = 1000;

        public event EventHandler? MainViewSelected;
        public event EventHandler? AddItemCountActionSelected;

        public void Display(params object[] model)
        {
            if (model is null)
            {
                throw new ArgumentNullException("Model is null");
            }
            if (model.Length != 1)
            {
                throw new ArgumentNullException("Wrong count models");
            }
            var items = model[0] as Dictionary<string, int>;
            if (items is null)
            {
                throw new ArgumentNullException("Wrong model passed");
            }

            Console.Clear();

            StringBuilder view = new StringBuilder();
            view.AppendLine("--------------------------");
            view.AppendLine("|     Add items page     |");
            view.AppendLine("--------------------------");
            view.AppendLine();
            view.AppendLine("List of items:");
            int itemsCounter = 1;
            foreach ( var item in items)
            {
                view.AppendLine($"\t{itemsCounter++} {item.Key, -6}\t{item.Value}");
            }
            view.AppendLine();
            view.AppendLine("--------------------------");
            view.AppendLine();
            view.AppendLine("Options: ");
            view.AppendLine("\t1: Add item count - [INDEX COUNT]");
            view.AppendLine("\tX: Back to main page");
            view.AppendLine();
            view.Append("Input: ");

            do
            {
                Console.Write(view);
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, ADD_ITEM_PATTERN))
                {
                    var match = Regex.Match(input, ADD_ITEM_PATTERN);
                    var itemIndexValue = match.Groups[1].Value;
                    var itemCountValue = match.Groups[2].Value;
                    if (int.TryParse(itemIndexValue, out int itemIndex) && 
                        int.TryParse(itemCountValue, out int itemCount))
                    {
                        if(itemIndex > 0 && itemIndex-1 < items.Count &&
                            itemCount > 0 && itemCount < ADD_ITEM_MAX_COUNT)
                        {
                            var itemName = items.ElementAt(itemIndex-1).Key;
                            AddItemCountActionSelected?.Invoke(this, new AddItemEventArgs(itemName, itemCount));
                            break;
                        }
                    }
                }
                else if (input?.ToUpper() == "X")
                {
                    MainViewSelected?.Invoke(this, new EventArgs());
                    break;
                }

                Console.Clear();

            } while (true);
        }
    }
}
