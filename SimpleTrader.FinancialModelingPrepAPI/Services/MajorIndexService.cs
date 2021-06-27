using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string uri = "quote/" + GetUriSuffix(indexType) + "?apikey=1ed128cab86b47b086ef17ff91eccb8f";

                MajorIndex majorIndex = await client.GetAsync<MajorIndex>(uri);
                majorIndex.Type = indexType;
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
                case MajorIndexType.Google:
                    return "GOOG";
                default:
                    throw new System.Exception("MajorIndexType does not have a suffix defined");
            }
        }
    }
}
