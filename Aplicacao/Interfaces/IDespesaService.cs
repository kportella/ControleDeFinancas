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
        Task<IEnumerable<DespesaDominio>> BuscarDespesas(string? descricao);
        Task<DespesaDominio> BuscarDespesa(long id);
        Task<DespesaDominio> AtualizarDespesa(DespesaDominio despesaDominio, long id);
        Task<bool> ExcluirDespesa(long id);



    }
}
