using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppTest.Services
{
    class DataServices //permet de se co aux données 
    {
        public async static Task<dynamic> GetDataFromService(string queryString)
        {
            HttpClient client = new HttpClient() ;
            var response = await client.GetAsync(queryString);

            if(response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                dynamic data = JsonConvert.DeserializeObject(json);
                return data; 
            }
            return null; 

        }


    }
}
