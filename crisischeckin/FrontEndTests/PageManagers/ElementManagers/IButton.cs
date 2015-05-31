namespace FrontEndTests.PageManagers.ElementManagers
{
    public interface IButton : IClickableElement
    {
         
    }

    public interface IToggleButton : IButton
    {
        bool IsTurnedOn { get; }
    }
}