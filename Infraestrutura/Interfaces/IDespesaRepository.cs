using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Interfaces
{
    public interface IDespesaRepository
    {
        Task<DespesaDominio> VerificarDespesaMes(DespesaDominio despesaDominio);
        Task<DespesaDominio> CadastrarDespesa(DespesaDominio despesaDominio);
        Task<IEnumerable<DespesaDominio>> BuscarTodasDespesas();
        Task<DespesaDominio> BuscarDespesa(long id);
        Task<DespesaDominio> AtualizarReceita(DespesaDominio despesaDominio);
        Task<bool> ExcluirDespesa(long id);
        Task<IEnumerable<DespesaDominio>> BuscarDespesasPorDescricao(string descricao);






    }
}
