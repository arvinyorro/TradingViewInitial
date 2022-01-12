using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Initial.Domain;
using Initial.Models;

namespace Initial.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndicatorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndicatorController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult AddIndicator(AddIndicatorModel model)
        {
            Batch batch = this._unitOfWork.BatchRepository.Get(model.BatchId);

            if (batch == null)
            {
                return BadRequest("Batch missing.");
            }

            if (!batch.Active)
            {
                return BadRequest("Batch inactive.");
            }

            var indicator = new Indicator(batch, model.Name, model.TimeInterval, model.Direction, model.Price);

            this._unitOfWork.IndicatorRepository.Add(indicator);

            this._unitOfWork.SaveChanges();

            return Ok();
        }
    }
}
