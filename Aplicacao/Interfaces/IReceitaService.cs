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
        Task<ReceitaDominio> CadastrarReceita(ReceitaDominio receitaDominio);
        Task<ReceitaDominio> BuscarReceita(long id);
        Task<IEnumerable<ReceitaDominio>> BuscarReceitas(string? descricao);
        Task<ReceitaDominio> AtualizarReceita(ReceitaDominio receitaDominio, long id);
        Task<bool> ExcluirReceita(long id);
        Task<IEnumerable<ReceitaDominio>> BuscarReceitasMes(int ano, int mes);
    }
}
