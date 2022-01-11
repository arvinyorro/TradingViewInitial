using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Initial.Domain;
using Initial.Models;

namespace Initial.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBinanceConfig _binanceConfig;

        public OrderController(IBinanceConfig binanceConfig)
        {
            _binanceConfig = binanceConfig;
        }

        private const string SignatureKey = "signature";

        [HttpPost("test-buy")]
        public IActionResult TestBuy()
        {
            string timeStamp = Math.Floor((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds).ToString();

            var queryList = new Dictionary<string, string>()
            {
                { "symbol", "BTCUSDT" },
                { "side", "SELL" },
                { "type", "MARKET" },
                //{ "timeInForce", "GTC" },
                { "quantity", "0.40616000" },
                //{ "price", "56500" },
                { "timestamp", timeStamp },
                { "signature", string.Empty },
            };

            IEnumerable<string> formattedQuery = queryList.Where(x => x.Key != "timestamp" && x.Key != SignatureKey).Select(x => $"{x.Key}={x.Value}");
            string paramQueryForHash = string.Join('&', formattedQuery);
            
            string hashText = $"{paramQueryForHash}&timestamp={timeStamp}";
            string secret = this._binanceConfig.GetApiSecret();
            string signatureHashed = this.GetHash(hashText, secret);

            bool hasSignature = queryList.Any(x => x.Key == SignatureKey);
            if (hasSignature)
            {
                queryList.Remove(SignatureKey);
                queryList.Add(SignatureKey, signatureHashed);
            }

            string baseUrl = "https://testnet.binance.vision";
            string endpoint = $"/api/v3/order";
            string apiKey = this._binanceConfig.GetApiKey();

            Task<IFlurlResponse> response = new Url(baseUrl)
                .AppendPathSegment(endpoint)
                .SetQueryParams(queryList)
                .WithHeader("X-MBX-APIKEY", apiKey)
                .PostAsync();

            TaskAwaiter<IFlurlResponse> responseAwaiter = response.GetAwaiter();

            IFlurlResponse result = responseAwaiter.GetResult();

            int statusCode = result.StatusCode;

            if (statusCode == 200)
            {
                return Ok("Posted!");
            }
            else
            {
                return BadRequest("Unable to post");
            }
        }

        [HttpPost("buy")]
        public IActionResult Buy(BuyOrderModel model)
        {
            string timeStamp = Math.Floor((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds).ToString();

            var queryList = new Dictionary<string, string>()
            {
                { "symbol", "BTCUSDT" },
                { "side", "SELL" },
                { "type", "LIMIT" },
                { "timeInForce", "GTC" },
                { "quantity", "0.01" },
                { "price", model.Price.ToString(CultureInfo.InvariantCulture) },
                { "timestamp", timeStamp },
                { "signature", string.Empty },
            };

            IEnumerable<string> formattedQuery = queryList.Where(x => x.Key != "timestamp" && x.Key != SignatureKey).Select(x => $"{x.Key}={x.Value}");
            string paramQueryForHash = string.Join('&', formattedQuery);

            string hashText = $"{paramQueryForHash}&timestamp={timeStamp}";
            string secret = "Gaw0mQGSi6QgGt3jCo9MkaOLC8ztKiOHKe9wfoWPSGZYP0zURMzNqXutOzTEIUqK";
            string signature = this.GetHash(hashText, secret);

            bool hasSignature = queryList.Any(x => x.Key == SignatureKey);
            if (hasSignature)
            {
                queryList.Remove(SignatureKey);
                queryList.Add(SignatureKey, signature);
            }

            string baseUrl = "https://testnet.binance.vision";
            string endpoint = $"/api/v3/order/test";

            Task<IFlurlResponse> response = new Url(baseUrl)
                .AppendPathSegment(endpoint)
                .SetQueryParams(queryList)
                .WithHeader("X-MBX-APIKEY", "ZZks9SAUXedZKZCNtVR0wkkg96Z88bisDGCW4WDdgIC2qxCC9UYTNLmJTPYqSer5")
                .PostAsync();

            TaskAwaiter<IFlurlResponse> responseAwaiter = response.GetAwaiter();

            IFlurlResponse result = responseAwaiter.GetResult();

            int statusCode = result.StatusCode;

            if (statusCode == 200)
            {
                return Ok("Posted!");
            }
            else
            {
                return BadRequest("Unable to post");
            }
        }

        [HttpGet("test")]
        public IActionResult TestConnection()
        {
            string baseUrl = this._binanceConfig.GetBaseUrl();
            string endpoint = "/api/v3/ping";

            Task<IFlurlResponse> response = new Url(baseUrl)
                .AppendPathSegment(endpoint)
                .GetAsync();

            TaskAwaiter<IFlurlResponse> responseAwaiter = response.GetAwaiter();

            IFlurlResponse result = responseAwaiter.GetResult();

            int statusCode = result.StatusCode;

            if (statusCode == 200)
            {
                return Ok("Connected!");
            }
            else
            {
                return BadRequest("No connection");
            }
        }

        public string GetHash(string text, string key)
        {
            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

    }
}
