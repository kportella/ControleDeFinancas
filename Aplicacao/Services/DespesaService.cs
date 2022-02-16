using Aplicacao.Interfaces;
using Dominio;
using Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;

        public DespesaService(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }
        public async Task<DespesaDominio> CadastrarDespesa(DespesaDominio despesaDominio)
        {
            if (despesaDominio == null) return null;
            if (!despesaDominio.VerificarDescricao()) return null;

            var cadastroRepetido = await _despesaRepository.VerificarDespesaMes(despesaDominio);
            if (cadastroRepetido != null) return null;
            var resultado = await _despesaRepository.CadastrarDespesa(despesaDominio);

            return resultado;
        }
        public async Task<IEnumerable<DespesaDominio>> BuscarTodasDespesas()
        {
            var resultados = await _despesaRepository.BuscarTodasDespesas();
            return resultados;
        }
        public async Task<DespesaDominio> BuscarDespesa(long id)
        {
            var resultado = await _despesaRepository.BuscarDespesa(id);
            return resultado;
        }
        public async Task<DespesaDominio> AtualizarDespesa(DespesaDominio despesaDominio, long id)
        {
            if (despesaDominio == null) return null;
            if (!despesaDominio.VerificarDescricao()) return null;

            var cadastroRepetido = await _despesaRepository.VerificarDespesaMes(despesaDominio);
            if (cadastroRepetido != null) return null;
            despesaDominio.Id = id;
            var resultado = await _despesaRepository.AtualizarReceita(despesaDominio);

            return resultado;
        }
    }
}
