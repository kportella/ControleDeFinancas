using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dtos
{
    public class ResumoDto
    {
        public decimal ReceitaMesTotal { get; set; }
        public decimal DespesaMesTotal { get; set; }
        public decimal SaldoFinalMes { get; set; }
    }
}
