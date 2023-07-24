namespace SuperHero.Dominio.Authentication
{
    public class JwtSettings
    {
        public static string JwtSection = "JwtSettings";
        public string Secret { get; set; }
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
