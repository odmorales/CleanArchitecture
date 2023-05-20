
using CleanArchitecture.Aplication.Models.Identity;

namespace CleanArchitecture.Aplication.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
