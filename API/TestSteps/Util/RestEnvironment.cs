using System.Configuration;

namespace API.TestSteps.Util
{
    class RestEnvironment
    {
        public static void SetEnvironment(string environmentUrl)
        {
            ConfigurationManager.AppSettings["restApi"] = environmentUrl;
        }
    }
}
