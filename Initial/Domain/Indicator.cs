using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initial.Domain
{
    public class Indicator
    {
        private long _batchId;

        protected Indicator()
        {

        }

        public long IndicatorId { get; private set; }

        public string Name { get; private set; }

        public string TimeInterval { get; private set; }

        public string Direction { get; private set; }

        public decimal Price { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public virtual Batch Batch { get; private set; }
    }
}
