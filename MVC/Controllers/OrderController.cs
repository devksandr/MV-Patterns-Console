using MVC.Models;
using MVC.Views.Order;

namespace MVC.Controllers
{
    public class OrderController
    {
        private MainView _mainView = new MainView();
        private ShowItemsListView _showItemsListView = new ShowItemsListView();
        private AddItemsView _addItemsView = new AddItemsView();

        private OrderModel _orderModel = new OrderModel();

        public OrderController()
        {
            _mainView.ShowItemsListViewSelected += GetShowItemsPage;
            _mainView.AddItemsViewSelected += GetAddItemsPage;

            _showItemsListView.MainViewSelected += GetMainPage;

            _addItemsView.MainViewSelected += GetMainPage;
            _addItemsView.AddItemCountActionSelected += AddItemCount;
        }


        private void GetMainPage(object? sender, EventArgs e) => GetMainPage();
        public void GetMainPage()
        {
            _mainView.Display();
        }

        private void GetShowItemsPage(object? sender, EventArgs e)
        {
            var items = _orderModel.GetItmesList();
            _showItemsListView.Display(items);
        }

        private void GetAddItemsPage(object? sender, EventArgs e) => GetAddItemsPage();
        private void GetAddItemsPage()
        {
            var items = _orderModel.GetAllItems();
            _addItemsView.Display(items);
        }

        private void AddItemCount(object? sender, EventArgs e)
        {
            var addItemArgs = e as AddItemEventArgs;
            if (addItemArgs is null)
            {
                throw new ArgumentNullException("Add item args are null");
            }
            
            _orderModel.AddItemCount(addItemArgs.Name, addItemArgs.Count);
            GetAddItemsPage();
        }
    }
}
