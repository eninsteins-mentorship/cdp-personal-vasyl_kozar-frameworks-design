using Chilkat;
using System;
using System.IO;

namespace API.TestSteps.Util
{
    internal static class JsonUtil
    {
        public static JsonObject LoadJsonObjectFromFile(string file)
        {
            return LoadJsonObject(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TestData\\" + file));
        }

        public static JsonArray LoadJsonArrayFromFile(string file)
        {
            return LoadJsonArray(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TestData\\" + file));
        }

        public static JsonObject LoadJsonObject(string jsonString)
        {
            var json = new JsonObject();
            json.Load(jsonString);
            return json;
        }

        public static JsonArray LoadJsonArray(string jsonString)
        {
            var json = new JsonArray();
            json.Load(jsonString);
            return json;
        }

        public static void PerformOperation(string type, object value, string jsonPath, ref JsonObject json)
        {
            json.Delete(jsonPath);
            switch(type)
            {
                case "string":
                    json.SetStringOf(jsonPath, value.ToString());
                    break;
                case "nimber":
                    json.SetNumberOf(jsonPath, value.ToString());
                    break;
                case "bool":
                    json.SetBoolOf(jsonPath, bool.Parse(value.ToString()));
                    break;
                case "empty":
                    json.SetStringOf(jsonPath, string.Empty);
                    break;
                case "null":
                    json.UpdateNull(jsonPath);
                    break;
            }
        }
    }
}
