using Acrelec.SCO.Core.Model.RestExchangedMessages;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Acrelec.SCO.Server.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api-sco/v{version:apiVersion}/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [MapToApiVersion("1")]
        public ActionResult Post([FromBody]InjectOrderRequest request)
        {
            try
            {
                if(request?.Customer == null)
                {
                    return StatusCode(400);
                }

                return Ok(new InjectOrderResponse() { OrderNumber = Guid.NewGuid().ToString()});
            }
            catch (Exception)
            {
                return StatusCode(500);
            }   
        }
    }
}
