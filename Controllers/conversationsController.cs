using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MinimalChatApplication.Constants;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.Model;
using MinimalChatApplication.Repository.Implementation;
using MinimalChatApplication.Repository.Interface;

namespace MinimalChatApplication.Controllers
{
    [Authorize]
    [Route(Constant.Route)]
    [ApiController]
    [Produces("application/json")]
    public class conversationsController : ControllerBase
    {
        private readonly IConversationsRepository _iConversationsRepository;

        public conversationsController(IConversationsRepository iConversationsRepository)
        {
            this._iConversationsRepository = iConversationsRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> RetrieveConversationHistory(string userId, [FromQuery] long? before = null, int? count = null, string? sort = null)
        {
            try
            {
                if (userId == string.Empty) return BadRequest(Constant.EnterMessageId);

                var lstMessage = await _iConversationsRepository.GetListMessage(userId);
                if (lstMessage == null && lstMessage.Count == 0)
                {
                    return NotFound(Constant.RecordNotFound);
                }
                

                var messageResult = await _iConversationsRepository.RetrieveConversationHistory(lstMessage, before, count, sort);
                if (messageResult != null)
                {
                    return Ok(messageResult);
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
