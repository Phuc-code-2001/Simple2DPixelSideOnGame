using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Sources.Scripts.SaveAndLoadData
{
    public class SaveGameManager
    {
        private static HttpClient _client = new HttpClient();

        public static List<Record> GetRecords()
        {
            var records = new List<Record>();
            try
            {
                string endpoint = "https://localhost:44376/Record/";
                var res = _client.GetAsync(endpoint).Result;
                if(res.IsSuccessStatusCode)
                {
                    string raw = res.Content.ReadAsStringAsync().Result;
                    records = JsonConvert.DeserializeObject<List<Record>>(raw);
                }
            }
            catch(Exception)
            {
                Debug.Log("Cannot connect to API...");
            }

            return records;
        }

        
    }
}
