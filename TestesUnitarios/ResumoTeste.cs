using Aplicacao.Interfaces;
using Aplicacao.Services;
using Dominio;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestesUnitarios
{
    public class ResumoTeste
    {
        private Mock<IDespesaService> _despesaServiceMock;
        private Mock<IReceitaService> _receitaServiceMock;

        #region BuscarResumoMes

        [Fact]
        public async void BuscarResumoMes_SemErros_RetornaResumo()
        {
            #region Arrange

            var receitas = new List<ReceitaDominio>()
            {
                new ReceitaDominio()
                {
                    Valor = 150
                }
            };

            var despesas = new List<DespesaDominio>()
            {
                new DespesaDominio()
                {
                    CategoriaId = 1,
                    Valor = 100
                }
            };

            var expected = new ResumoDominio()
            {
                Categorias = new List<CategoriaDespesaDominio>()
                {
                    new CategoriaDespesaDominio()
                    {
                        CategoriaId = 1,
                        ValorTotal = 100
                    }
                },
                DespesaMesTotal = 100,
                ReceitaMesTotal = 150
            };

            _despesaServiceMock = new Mock<IDespesaService>();
            _despesaServiceMock
                .Setup(d => d.BuscarDespesasMes(2020, 1))
                .ReturnsAsync(despesas);

            _receitaServiceMock = new Mock<IReceitaService>();
            _receitaServiceMock
                .Setup(r => r.BuscarReceitasMes(2020, 1))
                .ReturnsAsync(receitas);

            #endregion

            #region Act

            var resumoService = obterResumoService();
            var actual = await resumoService.BuscarResumoMes(2020, 1);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        #endregion


        public ResumoService obterResumoService()
        {
            return new ResumoService(_receitaServiceMock?.Object,
                _despesaServiceMock?.Object);
        }
    }
}
