using Dapper;
using Ganapati.Interface.Repo;
using Ganapati.Models;
using Ganapati.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace Ganapati.Repo
{
    public class PlayerRepo : IPlayerRepo
    {


        public async Task<bool> QueryUser(string userName, string password)
        {
            using (var conn = new SQLiteConnection(Const.connString))
            {
                var record = await conn.QueryFirstOrDefaultAsync<Player>(
                    "select * from Player where UserName = @userName And PassWord = @password Limit 1",
                    new { userName, password });
                return record != null;
            }
        }

        public async Task<bool> UpdateUser(string userName, string token, DateTime expiredTime)
        {
            using (var conn = new SQLiteConnection(Const.connString))
            {
                var result = await conn.ExecuteAsync(
                    "Update Player set Token = @token,ExpiredOn = @expiredTime Where UserName = @userName",
                    new { token, expiredTime = expiredTime.ToString("yyyy-MM-dd HH:mm:ss"), userName }
                    );
                return result > 0;
            }
        }

        public async Task<bool> CreateUser(string userName, string password)
        {
            using (var conn = new SQLiteConnection(Const.connString))
            {
                var result = await conn.ExecuteAsync(
                    "INSERT INTO Player VALUES (null,@userName,@password,datetime(\"now\"),null,null)",
                    new { userName, password }
                    );
                return result > 0;
            }
        }

        public async Task<GamePageResponse> GetLastRecord(int playerId)
        {
            using (var conn = new SQLiteConnection(Const.connString))
            {
                var record = await conn.QueryFirstOrDefaultAsync<GameRecord>(
                    "select * from GameRecord where PlayerId = @id order by datetime(PlayedOn) DESC Limit 1",
                    new { id = playerId });
                if (record == null) return null;
                return new GamePageResponse
                {
                    LastPlayerPoint = new List<int> { record.Point1, record.Point2 },
                    LastHostPoint = new List<int> { record.HostPoint1, record.HostPoint2 },
                };

            }
        }

        public async Task SaveRecord(int playerId, List<int> hostPoint, List<int> playerPoint)
        {
            using (var conn = new SQLiteConnection(Const.connString))
            {
                var result = await conn.ExecuteAsync(
                    "INSERT INTO GameRecord VALUES (null,@playerId,@p1,@p2,@hp1,@hp2,datetime(\"now\"))",
                    new { playerId = playerId, p1 = playerPoint[0], p2 = playerPoint[1], hp1 = hostPoint[0], hp2 = hostPoint[1] });
            }
        }
    }
}
