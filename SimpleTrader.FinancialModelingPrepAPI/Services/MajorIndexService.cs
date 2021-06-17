using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using (HttpClient client = new HttpClient())
            {
                string uri = "https://financialmodelingprep.com/api/v3/quote/" + GetUriSuffix(indexType) + "?apikey=1ed128cab86b47b086ef17ff91eccb8f";
                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonReponse = await response.Content.ReadAsStringAsync();
                jsonReponse = jsonReponse.Substring(1, jsonReponse.Length - 2);
                MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonReponse);
                return majorIndex;
            }
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.Apple:
                    return "AAPL";
                case MajorIndexType.Facebook:
                    return "FB";
                case MajorIndexType.SP500:
                    return "SP500";
                default:
                    return "AAPL";
            }
        }
    }
}
