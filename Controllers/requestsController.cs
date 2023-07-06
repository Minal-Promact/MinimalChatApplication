using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalChatApplication.Constants;
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
        public IActionResult logs([FromQuery] long? startDateTime = null, long? endDateTime = null)
        {
            try
            {
                if (startDateTime is long)
                {

                }
                else
                {
                    return BadRequest(Constant.EnterLongValue);
                }

                if (startDateTime == null)
                {
                    DateTime dateTime = DateTime.Now.AddMinutes(5);
                    DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
                    startDateTime = dateTimeOffset.ToUnixTimeSeconds();
                }

                if (endDateTime == null)
                {
                    DateTime dateTime = DateTime.Now;
                    DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
                    endDateTime = dateTimeOffset.ToUnixTimeSeconds();
                }

                // Retrieve the values from the HttpContext
                var value = HttpContext.Items["logMessages"];

                object v = HttpContext.Items["lstLogResponses"];

                List<LogResponse> lstLogResponse1 = (List<LogResponse>)v;
                if (lstLogResponse1 == null && lstLogResponse1.Count == 0)
                {
                    return NotFound(Constant.RecordNotFound);
                }
                List<LogResponse> logRes = lstLogResponse1.Where(log => log.TimeOfCall >= startDateTime && log.TimeOfCall <= endDateTime)
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
