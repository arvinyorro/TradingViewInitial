using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Initial.Domain
{
    public class Order
    {
        protected Order()
        {

        }

        public long OrderId { get; private set; }

        public decimal UnitAmount { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal TransactionAmount { get; private set; }

        public string  Direction { get; private set; }

        public  DateTime CreatedDateTime { get; private set; }

        public virtual Batch Batch { get; private set; }
    }
}
