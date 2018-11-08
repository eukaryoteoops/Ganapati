using Ganapati.Interface.Service;
using Ganapati.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ganapati.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("")]
        [CustomAuthorization]
        public async Task<ApiResponse<GamePageResponse>> InitPage()
        {
            var identity = ActionContext.RequestContext.Principal.Identity as ClaimsIdentity;
            var player = identity.FindFirst("PlayerId")?.Value;
            var playerId = Convert.ToInt32(player);
            var result = await _gameService.GetLastPoint(playerId);
            return new ApiResponse<GamePageResponse>(result);
        }

        [HttpGet]
        [Route("play")]
        [CustomAuthorization]
        public async Task<ApiResponse<PlayGameResponse>> PlayGame()
        {
            var identity = ActionContext.RequestContext.Principal.Identity as ClaimsIdentity;
            var player = identity.FindFirst("PlayerId")?.Value;
            var playerId = Convert.ToInt32(player);
            var result = await _gameService.GetGameResult(playerId);
            return new ApiResponse<PlayGameResponse>(result);
        }
    }
}