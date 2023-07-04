using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalChatApplication.Constants;
using MinimalChatApplication.Repository.Interface;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MinimalChatApplication.DTO.RequestDTO;
using AutoMapper;
using MinimalChatApplication.Model;
using Microsoft.AspNetCore.Authorization;

namespace MinimalChatApplication.Controllers
{
    [Authorize]
    [Route(Constant.Route)]
    [ApiController]
    public class messagesController : ControllerBase
    {
        private readonly IMessagesRepository _iMessagesRepository;
        private readonly IHttpContextAccessor _context;
        private readonly IMapper _mapper;

        public messagesController(IMessagesRepository iMessagesRepository, IHttpContextAccessor context, IMapper mapper)
        {
            this._iMessagesRepository = iMessagesRepository;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessagesRequestDTO sendMessagesRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var token = await HttpContext.GetTokenAsync("access_token");
                var messageRequestDTO = _mapper.Map<SendMessagesRequestDTO, Message>(sendMessagesRequestDTO);
                messageRequestDTO.senderId = this.User.Claims.FirstOrDefault(a => a.Type == "UserId").Value; 

                var message = await _iMessagesRepository.SendMessage(messageRequestDTO);
                if (message != null)
                {
                    return Ok(message);
                }
                return NotFound(Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, ex);
            }
        }

        [HttpPut("{messageId}")]
        public async Task<IActionResult> EditMessage(string messageId, [FromBody] EditMessageRequestDTO editMessageRequestDTO)
        {
            try
            {
                if (messageId == string.Empty) return BadRequest(Constant.EnterMessageId);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var message = await _iMessagesRepository.GetndCheckMessageById(messageId);
                if (message == null)
                {
                    return NotFound(Constant.RecordNotFound);
                }
                string senderId = this.User.Claims.FirstOrDefault(a => a.Type == "UserId").Value;
                if (message.senderId != senderId)
                {
                    return Unauthorized(Constant.UnauthorizedAccess);
                }

                message.senderId = senderId;
                message.content = editMessageRequestDTO.content;

                var messageResult = await _iMessagesRepository.EditMessage(message);
                if (messageResult != null)
                {
                    return Ok(Constant.MessageEditedSuccessfully);
                }
                return NotFound(Constant.RecordNotFound);
            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, ex);
            }
        }

        [HttpDelete("{messageId}")]
        public async Task<IActionResult> DeleteMessage(string messageId)
        {
            try
            {
                if (messageId == string.Empty) return BadRequest(Constant.EnterMessageId);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var message = await _iMessagesRepository.GetndCheckMessageById(messageId);
                if (message == null)
                {
                    return NotFound(Constant.RecordNotFound);
                }

                string senderId = this.User.Claims.FirstOrDefault(a => a.Type == "UserId").Value;
                if (message.senderId != senderId)
                {
                    return Unauthorized(Constant.UnauthorizedAccess);
                }               

                _iMessagesRepository.DeleteMessage(message);                
                return Ok(Constant.MessageDeletedSuccessfully);
                
            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, ex);
            }
        }
    }
}
