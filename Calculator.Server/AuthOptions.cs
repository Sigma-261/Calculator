using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Calculator.Server;

public class AuthOptions
{
    public const string ISSUER = "Server"; // издатель токена
    public const string AUDIENCE = "Client"; // потребитель токена
    const string KEY = "this is my custom Secret key for authentication";   // ключ для шифрации
    public const int LIFETIME = 1; // время жизни токена - 1 минута
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
