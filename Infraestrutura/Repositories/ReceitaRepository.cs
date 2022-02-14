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
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly MySQLContext _context;

        public ReceitaRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<ReceitaDominio> BuscarReceita(long id)
        {
            var resultado = await _context.Receita.Where(r => r.Id == id).FirstOrDefaultAsync();
            return resultado;
        }

        public async Task<ReceitaDominio> CadastroReceita(ReceitaDominio receitaDominio)
        {
            _context.Receita.Add(receitaDominio);
            await _context.SaveChangesAsync();
            return receitaDominio;
        }
    }
}