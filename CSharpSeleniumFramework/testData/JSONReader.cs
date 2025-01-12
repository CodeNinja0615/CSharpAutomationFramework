﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.testData
{
    public class JSONReader
    {

        public string ExtractData(string token)
        {
            var json = File.ReadAllText("testData/testData.json");
            var jsonObject = JToken.Parse(json);

            var selectedToken = jsonObject.SelectToken(token);
            if (selectedToken == null)
            {
                throw new ArgumentException($"The token '{token}' was not found in the JSON data.");
            }

            return selectedToken.Value<string>();
        }
        public String[] ExtractDataArray(string token)
        {
            var json = File.ReadAllText("testData/testData.json");
            var jsonObject = JToken.Parse(json);

            var selectedTokens = jsonObject.SelectTokens(token);
            if (selectedTokens == null)
            {
                throw new ArgumentException($"The token '{token}' was not found in the JSON data.");
            }

            IList<String> productsList = selectedTokens.Values<string>().ToList();

            return productsList.ToArray();
        }

        //public static List<Dictionary<string, string>> GetJsonDataToDictionary()
        //{
        //    string jsonContent = File.ReadAllText("testData/testData.json", Encoding.UTF8);
        //    var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonContent);

        //    return data;
        //}
    }
}
