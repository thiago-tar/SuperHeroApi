using SuperHero.Dominio.Entities;

namespace SuperHero.Dominio.Interfaces
{
    public class Hero : IHero
    {
        public static int Id = 0;

        public Hero()
        {
            Id++;
        }

        public Hero Crete()
        {
            return new Hero();
        }

        public string Test()
        {
            return "Works";
        }
    }
}
