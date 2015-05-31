namespace FrontEndTests.PageManagers.ElementManagers
{
    public interface IClickableElement : IBasicElement, IVisableElement, IEnabledElement
    {
        void Click();
    }
}