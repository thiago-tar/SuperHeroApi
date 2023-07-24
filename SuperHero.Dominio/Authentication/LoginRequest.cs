namespace SuperHero.Dominio.Authentication
{
    public record LoginRequest(
        string Email,
        string Password
        );
}
