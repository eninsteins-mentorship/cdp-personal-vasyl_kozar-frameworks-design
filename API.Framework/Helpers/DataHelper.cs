using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace API.Framework
{
    public class DataHelper
    {
        public static string directoryPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Method reads data from file and converts them to object
        /// </summary>
        /// <typeparam name="T">Type of expected object</typeparam>
        /// <param name="fileName">Name of file</param>
        /// <returns>Proper object</returns>
        public static T ReadObjectFromFile<T>(string fileName)
        {
            string FilePath = directoryPath + "..\\..\\TestData\\" + fileName;

            T fileObject = JsonConvert.DeserializeObject<T>(File.ReadAllText(@FilePath));

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

            List<T> fileObject = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(@FilePath));

            return fileObject;
        }
    }
}
