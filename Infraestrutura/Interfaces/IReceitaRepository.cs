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
        Task<ReceitaDominio> CadastroReceita(ReceitaDominio receitaDominio);
        Task<ReceitaDominio> BuscarReceita(long id);
        Task<ReceitaDominio> VerificarReceitaMes(ReceitaDominio receitaDominio);
        Task<IEnumerable<ReceitaDominio>> BuscarTodasReceitas();
        Task<ReceitaDominio> AtualizarReceita(ReceitaDominio receitaDominio);
    }
}
