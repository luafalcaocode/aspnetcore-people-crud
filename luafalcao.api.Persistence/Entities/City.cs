using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace luafalcao.api.Persistence.Entities
{
    [Table("Cidade")]
    public class City
    {
        [Column("Id")]
        public int CityId { get; set; }

        [Column("Nome")]
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Column("Uf")]
        [Required]
        [MaxLength(2)]
        public string Uf { get; set; }

        public ICollection<Person> People { get; set; }
    }
}
