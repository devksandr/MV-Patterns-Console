using System.Text;

namespace MVC.Views.Order
{
    public class MainView : IView
    {
        public event EventHandler? ShowItemsListViewSelected;
        public event EventHandler? AddItemsViewSelected;

        public void Display(params object[] model)
        {
            if (model != null && model.Length > 0)
            {
                throw new ArgumentException("Main page doesn't require arguments");
            }

            Console.Clear();

            StringBuilder view = new StringBuilder();
            view.AppendLine("--------------------------");
            view.AppendLine("|        Main page       |");
            view.AppendLine("--------------------------");
            view.AppendLine();
            view.AppendLine("Items actions");
            view.AppendLine();
            view.AppendLine("--------------------------");
            view.AppendLine();
            view.AppendLine("Options:");
            view.AppendLine("\t1: Show items list");
            view.AppendLine("\t2: Add items");
            view.AppendLine();
            view.Append("Input: ");

            do
            {
                Console.Write(view);
                var input = Console.ReadLine();
                if (input == "1")
                {
                    ShowItemsListViewSelected?.Invoke(this, new EventArgs());
                    break;
                }
                else if (input == "2")
                {
                    AddItemsViewSelected?.Invoke(this, new EventArgs());
                    break;
                }
                Console.Clear();

            } while (true);
        }
    }
}
