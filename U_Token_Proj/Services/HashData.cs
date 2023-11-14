using System.Security.Cryptography;
using System.Text;


namespace U_Token_Proj.Services;

public class HashData
{
    public static string HashPass(string password)
    {
        using (SHA512 sha512Hash = SHA512.Create())
        {

            byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            return hash;
        }
    }

}
