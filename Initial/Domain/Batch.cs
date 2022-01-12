using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initial.Domain
{
    public class Batch
    {
        protected Batch()
        {

        }

        public long BatchId { get; private set; }

        public string TradingSymbol { get; private set; }

        public decimal CapitalAmount { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public bool Active { get; private set; }
    }
}
