using System.Configuration;

namespace API.TestSteps.Util
{
    class ApiEnvironment
    {
        public static void SetEnvironment(string environmentUrl)
        {
            ConfigurationManager.AppSettings["restApi"] = environmentUrl;
        }
    }
}
