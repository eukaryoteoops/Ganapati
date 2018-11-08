using Ganapati.Interface.Repo;
using Ganapati.Interface.Service;
using Ganapati.Models;
using System;
using System.Threading.Tasks;

namespace Ganapati.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepo _playerRepo;

        public PlayerService(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }



        public async Task<TokenResponse> Login(LoginRequest req)
        {
            var IsValid = await _playerRepo.QueryUser(req.UserName, req.Password);
            if (IsValid)
            {
                var token = CreateToken();
                await _playerRepo.UpdateUser(req.UserName, token, DateTime.Now.AddMinutes(1));
                return new TokenResponse
                {
                    AccessToken = token,
                    Message = "Login Succeed."
                };
            }
            return new TokenResponse
            {
                AccessToken = null,
                Message = "Login failed."
            };

        }

        public async Task<TokenResponse> Register(RegisterRequest req)
        {
            var isSuccess = await _playerRepo.CreateUser(req.UserName, req.Password);
            if (isSuccess)
            {
                return await Login(new LoginRequest { UserName = req.UserName, Password = req.Password });
            }
            return new TokenResponse
            {
                AccessToken = null,
                Message = "Register failed."
            };
        }

        private string CreateToken()
        {
            var randomString = Guid.NewGuid().ToString();
            return randomString.Replace("-", "");
        }
    }
}
