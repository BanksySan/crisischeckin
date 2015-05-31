namespace FrontEndTests.Helpers
{
    internal static class Constants
    {
        public const string FrontEnd = "Front End";
        public const string BaseUrl = "http://localhost:2077/";
        public const string ChromeDriver = "ChromeDriver";
        public const string IeDriver = "IEDriver";
        public const string PhantomJsDriver = "PhantomJsDriver";

        public static IValidCredentials AdminCredentials { get; } = new ValidCredentials
        {
            UserName = "Administrator",
            Password = "P@$$w0rd"
        };
    }
}