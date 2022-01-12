using Initial.Domain;

namespace Initial.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BinanceBotContext _binanceBotContext;

        private IRepository<Batch> _batchRepository;
        private IRepository<Indicator> _indicatorRepository;

        public IRepository<Batch> BatchRepository
        {
            get
            {
                if (_batchRepository == null)
                {
                    _batchRepository = new SqlRepository<Batch>(_binanceBotContext);
                }

                return _batchRepository;
            }
        }

        public IRepository<Indicator> IndicatorRepository
        {
            get
            {
                if (_indicatorRepository == null)
                {
                    _indicatorRepository = new SqlRepository<Indicator>(_binanceBotContext);
                }

                return _indicatorRepository;
            }
        }


        public UnitOfWork(BinanceBotContext binanceBotContext)
        {
            _binanceBotContext = binanceBotContext;
        }

        public void SaveChanges()
        {
            _binanceBotContext.SaveChanges();
        }

        public bool HasDatabaseConnection()
        {
            return _binanceBotContext.HasDatabaseConnection();
        }
    }
}
