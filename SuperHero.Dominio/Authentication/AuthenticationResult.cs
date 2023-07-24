namespace SuperHero.Dominio.Authentication
{
    public record AuthenticationResult(
        Guid Id,
        string FirstName,
        string LasName,
        string Email,
        string Token
        );
}
