using Dominio;
using Infraestrutura.Context;
using Infraestrutura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly MySQLContext _context;

        public ReceitaRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<ReceitaDominio> AtualizarReceita(ReceitaDominio receitaDominio)
        {
            _context.Receita.Update(receitaDominio);
            await _context.SaveChangesAsync();
            return receitaDominio;
        }

        public async Task<ReceitaDominio> BuscarReceita(long id)
        {
            var resultado = await _context.Receita.Where(r => r.Id == id).FirstOrDefaultAsync();
            return resultado;
        }

        public async Task<IEnumerable<ReceitaDominio>> BuscarTodasReceitas()
        {
            var resultados = await _context.Receita.ToListAsync();
            return resultados;
        }

        public async Task<ReceitaDominio> CadastroReceita(ReceitaDominio receitaDominio)
        {
            _context.Receita.Add(receitaDominio);
            await _context.SaveChangesAsync();
            return receitaDominio;
        }

        public async Task<bool> ExcluirReceita(long id)
        {
            try
            {
                var receita = await _context.Receita.Where(r => r.Id == id).FirstOrDefaultAsync();
                if (receita == null) return false;
                _context.Receita.Remove(receita);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ReceitaDominio> VerificarReceitaMes(ReceitaDominio receitaDominio)
        {
            var resultado = await _context.Receita.Where(r => r.Descricao == receitaDominio.Descricao)
                .Where(r => r.DataDeCadastro.Month == receitaDominio.DataDeCadastro.Month)
                .FirstOrDefaultAsync();
            return resultado;
        }
    }
}
