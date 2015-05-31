namespace FrontEndTests.PageManagers.ElementManagers
{
    public static class NavigationBarStates
    {
        public static INavigationBarState Unauthenticated => new UnauthenticatedNavigationBarState();
    }
}