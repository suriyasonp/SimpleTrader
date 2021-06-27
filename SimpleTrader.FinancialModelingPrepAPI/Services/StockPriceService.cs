using Newtonsoft.Json;
using SimpleTrader.Domain.Exception;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string uri = "quote/" + symbol + "?apikey=1ed128cab86b47b086ef17ff91eccb8f";
                StockPriceResult stockPriceResult = await client.GetAsync<StockPriceResult>(uri);

                if (stockPriceResult == null || stockPriceResult.Price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }

                return stockPriceResult.Price;
            }
        }
    }
}
