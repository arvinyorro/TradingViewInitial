using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initial.Domain
{
    public interface IBinanceConfig
    {
        string GetApiKey();

        string GetApiSecret();

        string GetBaseUrl();
    }
}
