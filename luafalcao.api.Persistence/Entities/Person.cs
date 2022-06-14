using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace luafalcao.api.Persistence.Entities
{
    [Table("Pessoa")]
    public class Person
    {
        [Column("Id")]
        public int PersonId { get; set; }

        [Column("Nome")]
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [Column("CPF")]
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Column("Idade")]
        [Required]
        public string Age { get; set; }

        [ForeignKey(nameof(City))]
        [Column("Id_Cidade")]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}
