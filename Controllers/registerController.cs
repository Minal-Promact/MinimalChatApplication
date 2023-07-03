using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.Repository.Interface;
using MinimalChatApplication.Constants;

namespace MinimalChatApplication.Controllers
{
    [Route(Constant.Route)]
    [ApiController]
    public class registerController : ControllerBase
    {
        private readonly IRegisterRepository _iRegisterRepository;

        public registerController(IRegisterRepository iRegisterRepository)
        {
            this._iRegisterRepository= iRegisterRepository;
        }

        [HttpPost]        
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDTO userRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userRecord = await _iRegisterRepository.CheckEmailExistsInUser(userRequestDTO.email);
                if (userRecord != null)
                {
                    return Conflict(Constant.TheRecordAlreadyExists);
                }

                var result = await _iRegisterRepository.RegisterUser(userRequestDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, ex);
            }
        }
    }
}
