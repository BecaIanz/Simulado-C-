namespace FanficAPP.Services.JWT;

public interface IJWTService
{
    string CreateToken(ProfileToAuth data);
}