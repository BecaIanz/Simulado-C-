namespace FanficAPP.Services.JWT;

public record ProfileToAuth(
    //Nunca colocar a senha do usuario, pois não se passa dados criptografados no JWT para não ter vazamento de dados sensveis
    Guid UserId,
    string Username,
    string Email
);