using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        public FinancialModelingPrepHttpClient()
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
        }

        public async Task<T> GetAsync<T>(String uri)
        {
            HttpResponseMessage response = await GetAsync(uri);
            string jsonReponse = await response.Content.ReadAsStringAsync();
            jsonReponse = jsonReponse.Substring(1, jsonReponse.Length - 2);

            return JsonConvert.DeserializeObject<T>(jsonReponse);
        }
    }
}
