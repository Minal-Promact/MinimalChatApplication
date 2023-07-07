using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalChatApplication.Constants;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using System.Diagnostics.Eventing.Reader;

namespace MinimalChatApplication.Controllers
{
    [Authorize]
    [Route(Constant.Route)]
    [ApiController]
    public class requestsController : ControllerBase
    {
        [HttpGet]
        [Route(Constant.logs)]
        public IActionResult logs([FromQuery] FromQueryRequestLogging fromQueryRequestLogging)
        {
            try
            {               

                // Retrieve the values from the HttpContext
                var value = HttpContext.Items["logMessages"];

                object v = HttpContext.Items["lstLogResponses"];

                List<LogResponse> lstLogResponse1 = (List<LogResponse>)v;
                if (lstLogResponse1 == null && lstLogResponse1.Count == 0)
                {
                    return NotFound(Constant.RecordNotFound);
                }
                List<LogResponse> logRes = lstLogResponse1.Where(log => log.TimeOfCall >= fromQueryRequestLogging.StartDateTime && log.TimeOfCall <= fromQueryRequestLogging.EndDateTime).OrderBy(log=>log.TimeOfCall)
                    .ToList();

                if (logRes == null && logRes.Count == 0)
                {
                    return NotFound(Constant.RecordNotFound);
                }

                return Ok(logRes);
            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, ex);
            }

        }
    }
}
