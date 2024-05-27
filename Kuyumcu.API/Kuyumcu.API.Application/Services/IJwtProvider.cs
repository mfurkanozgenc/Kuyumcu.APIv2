using Kuyumcu.API.Application.Features.Auth.Login;
using Kuyumcu.API.Domain.Entities;

namespace Kuyumcu.API.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
