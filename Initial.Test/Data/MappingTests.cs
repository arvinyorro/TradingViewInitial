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
            var optionsBuilder = new DbContextOptionsBuilder<HorizonContext>();

            optionsBuilder.UseSqlServer(connectionString: "Server=.;Database=BinanceBot;Trusted_Connection=True;");

            var context = new HorizonContext(optionsBuilder.Options);

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
    }
}
