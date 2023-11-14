using U_Token_Proj.Dtos;
using U_Token_Proj.Entities;

namespace U_Token_Proj.Services.UserServices
{
    public interface IUserService
    {
        public ValueTask<List<User>> GetAllUsers();
        public ValueTask<User> CreateNewUser(UserCreateDto userCreateDto);
    }
}
