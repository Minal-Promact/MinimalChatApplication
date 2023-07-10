using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalChatApplication.Constants;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Model;
using MinimalChatApplication.Repository.Interface;
using System.Diagnostics.Eventing.Reader;

namespace MinimalChatApplication.Controllers
{
    [Authorize]
    [Route(Constant.Route)]
    [ApiController]
    public class requestsController : ControllerBase
    {
        private readonly IRequestLoggingMiddleware _iRequestLoggingMiddleware;

        public requestsController(IRequestLoggingMiddleware iRequestLoggingMiddleware)
        {
            _iRequestLoggingMiddleware = iRequestLoggingMiddleware;
        }

        [HttpGet]
        [Route(Constant.logs)]
        public async Task<IActionResult> logs([FromQuery] FromQueryRequestLogging fromQueryRequestLogging)
        {
            try
            {               
                /*
                // Retrieve the values from the HttpContext
                var value = HttpContext.Items["logMessages"];

                object v = HttpContext.Items["lstLogResponses"];

                List<LogResponse> lstLogResponse = (List<LogResponse>)v;
                if (lstLogResponse == null && lstLogResponse.Count == 0)
                {
                    return NotFound(Constant.RecordNotFound);
                }
                */

                List<RequestLogging> logRes = await _iRequestLoggingMiddleware.GetRequestLoggingMiddleware(fromQueryRequestLogging);
                    

                if (logRes != null && logRes.Count > 0)
                {
                    return Ok(logRes);
                }

                return NotFound(Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, ex);
            }

        }
    }
}
