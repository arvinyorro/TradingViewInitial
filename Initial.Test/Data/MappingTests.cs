using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Initial.Data;
using Initial.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Initial.Test.Data
{
    [TestClass]
    public class MappingTests
    {
        private UnitOfWork GetUnitOfWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BinanceBotContext>();

            optionsBuilder.UseSqlServer(connectionString: "Server=.;Database=BinanceBot;Trusted_Connection=True;");

            optionsBuilder.UseLazyLoadingProxies();

            var context = new BinanceBotContext(optionsBuilder.Options);

            return new UnitOfWork(context);
        }
        
        [TestMethod]
        public void GetQueryable_GivenBatch_ShouldMap()
        {
            // Prepare.
            UnitOfWork unitOfWork = this.GetUnitOfWork();

            // Act.
            Batch batch = unitOfWork.BatchRepository.GetQueryable().FirstOrDefault();
        }

        [TestMethod]
        public void GetQueryable_GivenIndicator_ShouldMap()
        {
            // Prepare.
            UnitOfWork unitOfWork = this.GetUnitOfWork();

            // Act.
            Indicator indicator = unitOfWork.IndicatorRepository.GetQueryable().FirstOrDefault();

            if (indicator != null)
            {
                Assert.IsNotNull(indicator.Batch);
            }
        }
    }
}
