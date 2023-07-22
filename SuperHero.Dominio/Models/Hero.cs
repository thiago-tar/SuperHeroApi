using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Dominio.Models
{
    public class Hero : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public City City { get; set; }

        public void Update(string name, string email)
        {
            ValidateData(name, email);
        }

        private void ValidateData(string nome, string email)
        {
            if (string.IsNullOrEmpty(nome))
                throw new InvalidOperationException("O nome é inválido");
            if (string.IsNullOrEmpty(email))
                throw new InvalidOperationException("O email é inválido");
        }
    }
}
