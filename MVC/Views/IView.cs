namespace MVC.Views
{
    internal interface IView
    {
        public void Display(params object[] model);
    }
}
