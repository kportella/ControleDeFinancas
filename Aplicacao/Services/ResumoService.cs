using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class ResumoService : IResumoService
    {
        private readonly IReceitaService _receitaService;
        private readonly IDespesaService _despesaService;

        public ResumoService(IReceitaService receitaService, IDespesaService despesaService)
        {
            _receitaService = receitaService;
            _despesaService = despesaService;
        }


        public async Task<ResumoDominio> BuscarResumoMes(int ano, int mes)
        {
            ResumoDominio resumoMes = new ResumoDominio();
            var receitasMes = await _receitaService.BuscarReceitasMes(ano, mes);
            foreach (ReceitaDominio receita in receitasMes)
            {
                resumoMes.ReceitaMesTotal += receita.Valor;
            }

            var despesasMes = await  _despesaService.BuscarDespesasMes(ano, mes);
            foreach (DespesaDominio despesa in despesasMes)
            {
                resumoMes.DespesaMesTotal += despesa.Valor;
            }
            var result = despesasMes.GroupBy(d => d.CategoriaId).Select(dg => new CategoriaDespesaDominio
            {
                CategoriaId = dg.First().CategoriaId,
                ValorTotal = dg.Sum(d => d.Valor)
            }).ToList();

            resumoMes.Categorias = result;
            return resumoMes;

        }
    }
}
