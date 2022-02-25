using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CategoriaDespesaDominio
    {
        public int CategoriaId { get; set; }

        public decimal ValorTotal { get; set; }
    }
}
