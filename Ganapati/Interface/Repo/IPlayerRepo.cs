using Ganapati.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ganapati.Interface.Repo
{
    public interface IPlayerRepo
    {
        Task<GamePageResponse> GetLastRecord(int playerId);
        Task SaveRecord(int playerId, List<int> hostPoint, List<int> playerPoint);
        Task<bool> CreateUser(string userName, string password);
        Task<bool> UpdateUser(string userName, string token, DateTime expiredTime);
        Task<bool> QueryUser(string userName, string password);
    }
}
