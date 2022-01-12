using Initial.Domain;

namespace Initial.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BinanceBotContext _binanceBotContext;

        private IRepository<Batch> _batchRepository;
        private IRepository<Indicator> _indicatorRepository;
        private IRepository<Order> _orderRepository;

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

        public IRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new SqlRepository<Order>(_binanceBotContext);
                }

                return _orderRepository;
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
