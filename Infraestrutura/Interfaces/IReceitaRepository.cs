using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Interfaces
{
    public interface IReceitaRepository
    {
        Task<ReceitaDominio> CadastrarReceita(ReceitaDominio receitaDominio);
        Task<ReceitaDominio> BuscarReceita(long id);
        Task<ReceitaDominio> VerificarReceitaMes(ReceitaDominio receitaDominio);
        Task<IEnumerable<ReceitaDominio>> BuscarTodasReceitas();
        Task<ReceitaDominio> AtualizarReceita(ReceitaDominio receitaDominio);
        Task<bool> ExcluirReceita(long id);
        Task<IEnumerable<ReceitaDominio>> BuscarReceitasPorDescricao(string descricao);

    }
}
