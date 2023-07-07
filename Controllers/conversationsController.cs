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
        public async Task<IActionResult> RetrieveConversationHistory(string userId, [FromQuery] FromQueryConversationHistory fromQueryConversationHistory)
        {
            try
            {
                if (userId == string.Empty) return BadRequest(Constant.EnterMessageId);
                

                if (fromQueryConversationHistory.Sort.ToLower() != "asc" && fromQueryConversationHistory.Sort.ToLower() != "desc")
                {
                    return BadRequest(Constant.InvalidParamter);
                }

                var lstMessage = await _iConversationsRepository.GetListMessage(userId);
                if (lstMessage == null && lstMessage.Count == 0)
                {
                    return NotFound(Constant.RecordNotFound);
                }
                

                var messageResult = await _iConversationsRepository.RetrieveConversationHistory(lstMessage, fromQueryConversationHistory);
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
