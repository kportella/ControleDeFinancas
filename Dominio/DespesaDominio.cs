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
        private const long OUTROS = 8;
        [ForeignKey("categoriaId")]
        public long CategoriaId { 
            get 
            {
                return CategoriaId;
            } 
            set 
            {
                if (this.CategoriaId > OUTROS) CategoriaId = OUTROS;
            } 
        }
    }
}
