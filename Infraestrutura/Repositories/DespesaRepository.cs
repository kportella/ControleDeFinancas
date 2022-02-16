﻿using Dominio;
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
    public class DespesaRepository : IDespesaRepository
    {
        private readonly MySQLContext _context;

        public DespesaRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<DespesaDominio> CadastrarDespesa(DespesaDominio despesaDominio)
        {
            _context.Despesa.Add(despesaDominio);
            await _context.SaveChangesAsync();
            return despesaDominio;
        }
        public async Task<DespesaDominio> VerificarDespesaMes(DespesaDominio despesaDominio)
        {
            var resultado = await _context.Despesa.Where(d => d.Descricao == despesaDominio.Descricao)
                .Where(d => d.DataDeCadastro.Month == despesaDominio.DataDeCadastro.Month)
                .FirstOrDefaultAsync();
            return resultado;
        }
        public async Task<IEnumerable<DespesaDominio>> BuscarTodasDespesas()
        {
            var resultados = await _context.Despesa.ToListAsync();
            return resultados;
        }
        public async Task<DespesaDominio> BuscarDespesa(long id)
        {
            var resultado = await _context.Despesa.Where(d => d.Id == id).FirstOrDefaultAsync();
            return resultado;
        }
    }
}
