using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Initial.Data;

namespace Initial.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly HorizonContext _dbContext;

        public TestsController(HorizonContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("db")]
        public ActionResult TestDatabaseConnection()
        {
            bool hasDatabaseConnection = this._dbContext.HasDatabaseConnection();

            if (!hasDatabaseConnection)
            {
                return BadRequest("Failed to connect to the database.");
            }

            return Ok();
        }
    }
}
