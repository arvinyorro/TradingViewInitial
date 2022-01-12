using Initial.Domain;

namespace Initial.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HorizonContext _horizonContext;

        private IRepository<Batch> _batchRepository;

        public IRepository<Batch> BatchRepository
        {
            get
            {
                if (_batchRepository == null)
                {
                    _batchRepository = new SqlRepository<Batch>(_horizonContext);
                }

                return _batchRepository;
            }
        }

        public UnitOfWork(HorizonContext horizonContext)
        {
            _horizonContext = horizonContext;
        }

        public void SaveChanges()
        {
            _horizonContext.SaveChanges();
        }

        public bool HasDatabaseConnection()
        {
            return _horizonContext.HasDatabaseConnection();
        }
    }
}
