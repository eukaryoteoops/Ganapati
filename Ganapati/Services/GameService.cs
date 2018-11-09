using Ganapati.Interface.Repo;
using Ganapati.Interface.Service;
using Ganapati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganapati.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayerRepo _playerRepo;

        public GameService(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public async Task<PlayGameResponse> GetGameResult(int playerId)
        {
            var hostPoint = RandomNumber(1, 6, 2);
            var playerPoint = RandomNumber(1, 6, 2);
            var winner = playerPoint.Sum() - hostPoint.Sum() == 0 ? "Draw" : playerPoint.Sum() > hostPoint.Sum() ? "Player Win" : "Host Win";

            var lastPoint = await GetLastPoint(playerId);
            await _playerRepo.SaveRecord(playerId, hostPoint, playerPoint);
            return new PlayGameResponse
            {
                Winner = winner,
                HostPoint = hostPoint,
                PlayerPoint = playerPoint,
                LastHostPoint = lastPoint?.LastHostPoint,
                LastPlayerPoint = lastPoint?.LastPlayerPoint
            };
        }

        public async Task<GamePageResponse> GetLastPoint(int playerId)
        {
            return await _playerRepo.GetLastRecord(playerId);
        }

        private List<int> RandomNumber(int min, int max, int count)
        {
            var result = new List<int>();
            for (int i = 0; i < count; i++)
            {
                var rnd = new Random(Guid.NewGuid().GetHashCode());
                result.Add(Enumerable.Range(min, max).OrderBy(x => rnd.Next()).First());
            }
            return result;
        }
    }
}
