namespace FrontEndTests.PageManagers.ElementManagers
{
    public class UnauthenticatedNavigationBarState : INavigationBarState
    {
        public IWebElementState HomeButton => new ClickableWebElementState();
        public IWebElementState LogInButton => new ClickableWebElementState();
    }
}