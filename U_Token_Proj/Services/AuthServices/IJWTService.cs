namespace U_Token_Proj.Services.AuthServices
{
    public interface IJWTService
    {
        string Generate(string username);
    }
}
