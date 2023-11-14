using Microsoft.EntityFrameworkCore;
using U_Token_Proj.DataAccsess;
using U_Token_Proj.Dtos;
using U_Token_Proj.Entities;

namespace U_Token_Proj.Services.UserServices
{
    public class UserService : IUserService
    {
        public readonly DataContext _dbContext;

        public UserService(DataContext context)
        {
            _dbContext = context;
        }

        public async ValueTask<User> CreateNewUser(UserCreateDto userCreateDto)
        {
            var newUser = new User()
            {
                UserName = userCreateDto.UserName,
                PasswordHash = HashData.HashPass(userCreateDto.PasswordHash),
            };


            await _dbContext.Users.AddAsync(newUser);

            await _dbContext.SaveChangesAsync();
            return newUser;
        }

        public async ValueTask<List<User>> GetAllUsers()
        {
            var result = await _dbContext.Users.ToListAsync();
            return result;
        }
    }
}
