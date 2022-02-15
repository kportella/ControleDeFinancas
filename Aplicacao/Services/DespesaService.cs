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

            var cadastroRepetido = await _despesaRepository.VerificarReceitaMes(despesaDominio);
            if (cadastroRepetido != null) return null;
            var resultado = await _despesaRepository.CadastrarDespesa(despesaDominio);

            return resultado;
        }
    }
}
