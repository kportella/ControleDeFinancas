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
        private const int OUTROSID = 8;
        private readonly IDespesaRepository _despesaRepository;

        public DespesaService(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }
        public async Task<DespesaDominio> CadastrarDespesa(DespesaDominio despesaDominio)
        {
            if (despesaDominio == null) return null;
            if (!despesaDominio.VerificarDescricao()) return null;

            if (despesaDominio.CategoriaId > OUTROSID) despesaDominio.CategoriaId = OUTROSID;

            var cadastroRepetido = await _despesaRepository.VerificarDespesaMes(despesaDominio);
            if (cadastroRepetido != null) return null;
            var resultado = await _despesaRepository.CadastrarDespesa(despesaDominio);

            return resultado;
        }
        public async Task<IEnumerable<DespesaDominio>> BuscarDespesas(string? descricao)
        {
            IEnumerable<DespesaDominio> resultados;
            if (descricao == null) resultados = await _despesaRepository.BuscarTodasDespesas();
            else resultados = await _despesaRepository.BuscarDespesasPorDescricao(descricao);
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
        public async Task<bool> ExcluirDespesa(long id)
        {
            var resultado = await _despesaRepository.ExcluirDespesa(id);

            return resultado;
        }
        public async Task<IEnumerable<DespesaDominio>> BuscarDespesasMes(int ano, int mes)
        {
            var resultados = await _despesaRepository.BuscarDespesasMes(ano, mes);
            return resultados;
        }
    }
}
