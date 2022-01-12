using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initial.Domain
{
    public interface IUnitOfWork
    {
        IRepository<Batch> BatchRepository { get; }

        IRepository<Indicator> IndicatorRepository { get; }

        void SaveChanges();

        bool HasDatabaseConnection();
    }
}
