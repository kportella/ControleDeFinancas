using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dtos
{
    public class ReceitaDto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeCadastro { get; set; }
    }
}
