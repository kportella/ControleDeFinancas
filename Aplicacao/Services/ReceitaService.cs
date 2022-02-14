using Aplicacao.Interfaces;
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

        public async Task<ReceitaDominio> AtualizarReceita(ReceitaDominio receitaDominio, long id)
        {
            if (receitaDominio == null) return null;
            if (!receitaDominio.VerificarDescricao()) return null;

            var cadastroRepetido = await _receitaRepository.VerificarReceitaMes(receitaDominio);
            if (cadastroRepetido != null) return null;
            receitaDominio.Id = id;
            var resultado = await _receitaRepository.AtualizarReceita(receitaDominio);

            return resultado;
        }

        public async Task<ReceitaDominio> BuscarReceita(long id)
        {
            var resultado = await _receitaRepository.BuscarReceita(id);
            return resultado;
        }

        public async Task<IEnumerable<ReceitaDominio>> BuscarTodasReceitas()
        {
            var resultados = await _receitaRepository.BuscarTodasReceitas();
            return resultados;
        }

        public async Task<ReceitaDominio> CadastroReceita(ReceitaDominio receitaDominio)
        {
            if (receitaDominio == null) return null;
            if (!receitaDominio.VerificarDescricao()) return null;

            var cadastroRepetido = await _receitaRepository.VerificarReceitaMes(receitaDominio);
            if (cadastroRepetido != null) return null;
            var resultado = await _receitaRepository.CadastroReceita(receitaDominio);
            
            return resultado;
        }
    }
}
