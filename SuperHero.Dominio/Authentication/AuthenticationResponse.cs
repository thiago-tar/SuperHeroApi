namespace SuperHero.Dominio.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string FirstName,
        string LasName,
        string Email,
        string Token
        );
}
