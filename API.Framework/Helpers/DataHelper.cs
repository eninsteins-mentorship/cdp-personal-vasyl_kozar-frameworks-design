using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using NLog;

namespace API.Framework
{
    public class DataHelper
    {
        public static string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Method reads data from file and converts them to object
        /// </summary>
        /// <typeparam name="T">Type of expected object</typeparam>
        /// <param name="fileName">Name of file</param>
        /// <returns>Proper object</returns>
        public static T ReadObjectFromFile<T>(string fileName) where T : new()
        {
            T fileObject = new T();
            string FilePath = directoryPath + "..\\..\\TestData\\" + fileName;

            try
            {
                fileObject = JsonConvert.DeserializeObject<T>(File.ReadAllText(@FilePath));
                logger.Info($"The object was mapped from {fileName} file sucessfully.");
            }
            catch (Exception exception)
            {
                logger.Error($"Can't read from {fileName} file. Details: {exception}");
            }

            return fileObject;
        }

        /// <summary>
        /// Method reads data from file and returns List of objects
        /// </summary>
        /// <typeparam name="T">Type of expected objects</typeparam>
        /// <param name="fileName">Name of file</param>
        /// <returns></returns>
        public static List<T> ReadListObjectsFromFile<T>(string fileName)
        {
            string FilePath = directoryPath + "\\" + fileName;
            List<T> fileObject = new List<T>();

            try
            {
                fileObject = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(@FilePath));
                logger.Info($"The list of object was mapped from {fileName} file sucessfully.");
            }
            catch (Exception exception)
            {
                logger.Error($"Can't read from {fileName} file. Details: {exception}");
            }

            return fileObject;
        }
    }
}
