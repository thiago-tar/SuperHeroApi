namespace SuperHero.Dominio.Authentication
{
    public record RegisterRequest(
        string FirstName,
        string LasName,
        string Email,
        string Password
        );
}
