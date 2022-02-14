using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Base
{
    public class BaseDominio
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("descricao")]
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Column("valor")]
        [Required]
        [Range(1,100000)]
        public decimal Valor { get; set; }
        [Column("dataCadastro")]
        [Required]
        public DateTime DataDeCadastro { get; set; }
    }
}
