using Ganapati.Models;
using System.Threading.Tasks;

namespace Ganapati.Interface.Service
{
    public interface IGameService
    {
        Task<PlayGameResponse> GetGameResult(int playerId);
        Task<GamePageResponse> GetLastPoint(int playerId);
    }
}
