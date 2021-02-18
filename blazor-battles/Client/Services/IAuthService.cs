using System.Threading.Tasks;
using blazor_battles.Shared;

namespace blazor_battles.Client.Services
{
    public interface IAuthService
    { 
        Task<ServiceResponse<int>> Register(UserRegister request);
    }
}