using Ganapati.Interface.Service;
using Ganapati.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ganapati.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IPlayerService _playerService;

        public AuthController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost, Route("register")]
        public async Task<ApiResponse<TokenResponse>> Register([FromBody]RegisterRequest req)
        {
            if (ModelState.IsValid)
            {
                var result = await _playerService.Register(req);
                return new ApiResponse<TokenResponse>(result);
            }
            return new ApiResponse<TokenResponse>(new TokenResponse { Message = "Model Error" });

        }

        [HttpPost, Route("login")]
        public async Task<ApiResponse<TokenResponse>> Login([FromBody]LoginRequest req)
        {
            if (ModelState.IsValid)
            {
                var result = await _playerService.Login(req);
                return new ApiResponse<TokenResponse>(result);
            }
            return new ApiResponse<TokenResponse>(new TokenResponse { Message = "Model Error" });
        }
    }
}