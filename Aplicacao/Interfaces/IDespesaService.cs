using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IDespesaService
    {
        Task<DespesaDominio> CadastrarDespesa(DespesaDominio despesaDominio);
        Task<IEnumerable<DespesaDominio>> BuscarTodasDespesas();
        Task<DespesaDominio> BuscarDespesa(long id);


    }
}
