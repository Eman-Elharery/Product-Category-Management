using lab3.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace lab3.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterVM model);
        Task<SignInResult> LoginAsync(LoginVM model);
        Task LogoutAsync();
    }
}
