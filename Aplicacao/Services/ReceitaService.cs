﻿using Aplicacao.Interfaces;
using Aplicacao.Dtos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestrutura.Interfaces;

namespace Aplicacao.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaService(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public async Task<ReceitaDominio> BuscarReceita(long id)
        {
            var resultado = await _receitaRepository.BuscarReceita(id);
            return resultado;
        }

        public async Task<ReceitaDominio> CadastroReceita(ReceitaDominio receitaDominio)
        {
            if (receitaDominio == null)
            {
                return null;
            }
            if (!receitaDominio.VerificarDescricao()) return null;
            var resultado = await _receitaRepository.CadastroReceita(receitaDominio);
            
            return resultado;
        }
    }
}