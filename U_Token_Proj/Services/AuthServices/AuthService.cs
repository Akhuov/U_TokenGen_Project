using Microsoft.EntityFrameworkCore;
using U_Token_Proj.DataAccsess;
using U_Token_Proj.Model;

namespace U_Token_Proj.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dbContext;
        private readonly IJWTService _tokenSerice;

        public AuthService(DataContext applicationDbContext, IJWTService tokenService)
        {
            _dbContext = applicationDbContext;
            _tokenSerice = tokenService;
        }
        public async ValueTask<string> Login(LoginRequest request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            else if (user.PasswordHash != request.Password)
            {
                throw new Exception("Password is wrong");
            }

            return _tokenSerice.Generate(user.UserName);

        }
    }
}
