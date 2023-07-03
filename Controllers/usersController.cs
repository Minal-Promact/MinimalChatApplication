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
           var result = await _iUserRepository.GetListOfUser();
            return Ok(result);
        }
    }
}
