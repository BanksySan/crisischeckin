namespace FrontEndTests.PageManagers.ElementManagers
{
    public interface IClickable
    {
        void Click();
    }

    public interface IClickable<out T>
    {
        T Click();
    }
}