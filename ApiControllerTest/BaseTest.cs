namespace ApiControllerTest
{
    /// <summary>
    /// Basic test including some basic behaviours
    /// </summary>
    public abstract class BaseTest
    {
        public BaseTest()
        {
            ConfigTest();
        }
        protected abstract void ConfigTest();
    }
}
