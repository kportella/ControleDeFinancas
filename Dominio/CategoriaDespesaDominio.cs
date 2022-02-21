using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("categoria")]
    public class CategoriaDespesaDominio
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("categoria")]
        [Required]
        [StringLength(100)]
        public string Categoria { get; set; }
    }
}
