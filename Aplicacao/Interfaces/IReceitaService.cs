using Aplicacao.Dtos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IReceitaService
    {
        Task<ReceitaDominio> CadastroReceita(ReceitaDominio receitaDominio);
        Task<ReceitaDominio> BuscarReceita(long id);
        Task<IEnumerable<ReceitaDominio>> BuscarTodasReceitas();
        Task<ReceitaDominio> AtualizarReceita(ReceitaDominio receitaDominio, long id);
        Task<bool> ExcluirReceita(long id);
    }
}
