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

        public List<Record> GetRecords()
        {
            var records = new List<Record>();
            try
            {
                string endpoint = "https://localhost:44376/api/Record/";
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

        public Record SaveRecord(Record record, bool isUpdate = false)
        {
            try
            {
                string endpoint = "https://localhost:44376/api/Record/";
                StringContent data = new StringContent(JsonConvert.SerializeObject(record), Encoding.UTF8, "application/json");
            
                var res = isUpdate ? _client.PutAsync(endpoint, data).Result : _client.PostAsync(endpoint, data).Result;
                if (res.IsSuccessStatusCode)
                {
                    string raw = res.Content.ReadAsStringAsync().Result;
                    Record result = JsonConvert.DeserializeObject<Record>(raw);
                    return result;
                }
            }
            catch (Exception)
            {
                Debug.Log("Cannot connect to API...");
            }

            return record;
        }
    }
}
