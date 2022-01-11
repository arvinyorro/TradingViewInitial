using Initial.Domain;
using Microsoft.Extensions.Configuration;

namespace Initial.Components
{
    public class WebApiConfig : IBinanceConfig
    {
        private readonly IConfiguration _configuration;

        public WebApiConfig(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GetApiKey()
        {
            var apiKey = this._configuration.GetValue<string>("BinanceApiKey");

            return apiKey;
        }

        public string GetApiSecret()
        {
            var apiKey = this._configuration.GetValue<string>("BinanceApiSecret");

            return apiKey;
        }

        public string GetBaseUrl()
        {
            var baseUrl = this._configuration.GetValue<string>("BinanceApiBaseUrl");

            return baseUrl;
        }
    }
}
