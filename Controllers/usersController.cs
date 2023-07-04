using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalChatApplication.Constants;
using MinimalChatApplication.Repository.Interface;

namespace MinimalChatApplication.Controllers
{
    [Authorize]
    [Route(Constant.Route)]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly IUserRepository _iUserRepository;

        public usersController(IUserRepository iUserRepository)
        {
            this._iUserRepository = iUserRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var result = await _iUserRepository.GetListOfUser();
                if (result != null)
                {
                    return Ok(result);
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
