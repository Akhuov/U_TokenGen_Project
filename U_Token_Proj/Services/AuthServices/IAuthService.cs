using U_Token_Proj.Model;

namespace U_Token_Proj.Services.AuthServices
{
    public interface IAuthService
    {
        ValueTask<string> Login(LoginRequest request);
    }
}
