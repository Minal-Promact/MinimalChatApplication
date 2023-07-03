using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalChatApplication.Constants;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Repository.Implementation;
using MinimalChatApplication.Repository.Interface;

namespace MinimalChatApplication.Controllers
{
    [Route(Constant.Route)]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly ILoginRepository _iLoginRepository;

        public loginController(ILoginRepository iLoginRepository)
        {
            this._iLoginRepository = iLoginRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostLoginDetails([FromBody] LoginRequestDTO loginRequestDTO)
        {
            try
            {
                JWTTokenResponseDTO jWTTokenResponseDTO = new JWTTokenResponseDTO();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var loginRecord = await _iLoginRepository.CheckUserDetails(loginRequestDTO);
                if (loginRecord != null)
                {
                    var resultToken = await _iLoginRepository.GetJWTTokenFromUserDetails(loginRecord);
                    if (resultToken != null)
                    {
                        return Ok(resultToken);
                    }                    
                }
                return Unauthorized(Constant.LoginFailedDueToIncorrectCredentials);

            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, ex);
            }
        }
    }
}
