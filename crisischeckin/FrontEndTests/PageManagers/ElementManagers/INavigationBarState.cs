namespace FrontEndTests.PageManagers.ElementManagers
{
    public interface INavigationBarState
    {
        IWebElementState HomeButton { get; }

        IWebElementState LogInButton { get; }
    }
}