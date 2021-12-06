using Acrelec.SCO.Core.Model.RestExchangedMessages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acrelec.SCO.Server.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api-sco/v{version:apiVersion}/[controller]")]
    public class Availability : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1")]
        public ActionResult Get()
        {
            try
            {
                return Ok(new CheckAvailabilityResponse{ CanInjectOrders = true });
            }
            catch(InvalidOperationException)
            {
                return Ok(new CheckAvailabilityResponse { CanInjectOrders = false });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
