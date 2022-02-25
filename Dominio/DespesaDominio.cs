using Dominio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("despesa")]
    public class DespesaDominio: BaseDominio
    {
        [ForeignKey("categoriaId")]
        public int CategoriaId { get; set; }
    }
}
