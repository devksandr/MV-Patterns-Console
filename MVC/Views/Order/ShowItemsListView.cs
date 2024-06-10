using System.Text;

namespace MVC.Views.Order
{
    public class ShowItemsListView : IView
    {
        public event EventHandler? MainViewSelected;

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
            var items = model[0] as List<string>;
            if (items is null)
            {
                throw new ArgumentNullException("Wrong model passed");
            }

            Console.Clear();

            StringBuilder view = new StringBuilder();
            view.AppendLine("--------------------------");
            view.AppendLine("|       Items page       |");
            view.AppendLine("--------------------------");
            view.AppendLine();
            view.AppendLine("List of items:");
            int itemsCounter = 1;
            items.ForEach(i => view.AppendLine($"\t{itemsCounter++} {i}"));
            view.AppendLine();
            view.AppendLine("--------------------------");
            view.AppendLine();
            view.AppendLine("Options: ");
            view.AppendLine("\tX: Back to main page");
            view.AppendLine();
            view.Append("Input: ");

            do
            {
                Console.Write(view);
                var input = Console.ReadLine();
                if (input?.ToUpper() == "X")
                {
                    MainViewSelected?.Invoke(this, new EventArgs());
                    break;
                }

                Console.Clear();

            } while (true);
        }
    }
}
