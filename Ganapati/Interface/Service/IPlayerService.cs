using Ganapati.Models;
using System.Threading.Tasks;

namespace Ganapati.Interface.Service
{
    public interface IPlayerService
    {
        Task<TokenResponse> Register(RegisterRequest req);
        Task<TokenResponse> Login(LoginRequest req);
    }
}
