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

        public async Task<IEnumerable<ReceitaDominio>> BuscarReceitas(string? descricao)
        {
            IEnumerable<ReceitaDominio> resultados;
            if (descricao == null) resultados = await _receitaRepository.BuscarTodasReceitas();
            else resultados = await _receitaRepository.BuscarReceitasPorDescricao(descricao);
            return resultados;
        }

        public async Task<IEnumerable<ReceitaDominio>> BuscarReceitasMes(int ano, int mes)
        {
            var resultados = await _receitaRepository.BuscarReceitasMes(ano, mes);
            return resultados;
        }

        public async Task<ReceitaDominio> CadastrarReceita(ReceitaDominio receitaDominio)
        {
            if (receitaDominio == null) return null;
            if (!receitaDominio.VerificarDescricao()) return null;

            var cadastroRepetido = await _receitaRepository.VerificarReceitaMes(receitaDominio);
            if (cadastroRepetido != null) return null;
            var resultado = await _receitaRepository.CadastrarReceita(receitaDominio);
            
            return resultado;
        }

        public async Task<bool> ExcluirReceita(long id)
        {
            var resultado = await _receitaRepository.ExcluirReceita(id);

            return resultado;
        }
    }
}
