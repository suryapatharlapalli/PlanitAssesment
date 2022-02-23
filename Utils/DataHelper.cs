using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace PlanitAssesment.Utils
{
    public class DataHelper
    {
        /// <summary>Read testdata from Json</summary>
        /// <param name="FilePath">Path of Json testdata file</param>
        ///  /// <param name="TestCaseName">Test Case Name</param>
        /// Updated By :      
        public Dictionary<string, string> ReadTestDataFromJSONFile(string FilePath, string TestCaseName)
        {
            string jKey = null;
            string jValue = null;
            Dictionary<string, string> jsonData = new Dictionary<string, string>();
            using (var reader = new StreamReader(FilePath))
            {
                var strResultjson = File.ReadAllText(FilePath);
                var dictionary = JsonConvert.DeserializeObject<IDictionary>(strResultjson);
                foreach (DictionaryEntry entry in dictionary)
                {
                    string key = null;
                    string value = null;
                    key = entry.Key.ToString();
                    if (key.Equals(TestCaseName))
                    {
                        value = entry.Value.ToString().Replace("{", "").Replace("}", "").Replace("\"", "").TrimEnd('\n');
                        string[] items = value.Split('\n');
                        foreach (string item in items.Skip(1))
                        {
                            string[] keyValue = item.Split(':');
                            jKey = keyValue[0].Trim();
                            jValue = keyValue[1].Trim().TrimEnd(',');
                            if (jValue != "null")
                            {
                                jsonData[jKey] = jValue;
                            }
                        }
                    }
                }
            }
            return jsonData;
        }
    }
}
