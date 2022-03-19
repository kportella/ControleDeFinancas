using Aplicacao.Services;
using Dominio;
using FluentAssertions;
using Infraestrutura.Interfaces;
using Infraestrutura.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestesUnitarios
{
    public class DespesaTeste
    {
        private Mock<IDespesaRepository> _despesaRepositoryMock;

        #region CadastrarDespesa

        [Fact]
        public async void CadastrarDespesa_SemErros_RetornaDespesaDominio()
        {
            #region Arrange

            var expected = new Mock<DespesaDominio>().SetupAllProperties()
                .Object;
            expected.Descricao = "descricao";


            _despesaRepositoryMock = new Mock<IDespesaRepository>();
            _despesaRepositoryMock
                .Setup(d => d.CadastrarDespesa(expected))
                .ReturnsAsync(expected);
            _despesaRepositoryMock
                .Setup(d => d.VerificarDespesaMes(expected))
                .Returns(Task.FromResult<DespesaDominio>(null));
            
            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.CadastrarDespesa(expected);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion

        }
        [Fact]
        public async void CadastrarDespesa_CadastroRepetido_RetornaNulo()
        {
            #region Arrange

            var despesaDominio = new Mock<DespesaDominio>().SetupAllProperties()
                .Object;
            despesaDominio.Descricao = "descricao";


            _despesaRepositoryMock = new Mock<IDespesaRepository>();
            _despesaRepositoryMock
                .Setup(d => d.VerificarDespesaMes(despesaDominio))
                .Returns(Task.FromResult(despesaDominio));

            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.CadastrarDespesa(despesaDominio);

            #endregion

            #region Assert

            DespesaDominio expected = null;

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        [Fact]
        public async void CadastrarDespesa_SemDescricao_RetornaNulo()
        {
            #region Arrange

            var despesaDominio = new Mock<DespesaDominio>()
                .SetupAllProperties()
                .Object;
            despesaDominio.Descricao = "";
            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.CadastrarDespesa(despesaDominio);

            #endregion

            #region Assert

            DespesaDominio expected = null;

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        [Fact]
        public async void CadastrarDespesa_SemDespesaDominio_RetornaNulo()
        {
            #region Arrange

            DespesaDominio expected = null;

            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.CadastrarDespesa(expected);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        #endregion


        #region BuscarDespesas

        [Fact]
        public async void BuscarDespesas_ComDescricao_RetornaDespesa()
        {
            #region Arrange

            var descricao = "descricao";
            IEnumerable<DespesaDominio> expected = new List<DespesaDominio>()
            {
                new Mock<DespesaDominio>().Object
            };

            _despesaRepositoryMock = new Mock<IDespesaRepository>();
            _despesaRepositoryMock
                .Setup(d => d.BuscarDespesasPorDescricao(descricao))
                .ReturnsAsync(expected);

            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.BuscarDespesas(descricao);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion

        }

        [Fact]
        public async void BuscarDespesas_SemDescricao_RetornaDespesa()
        {
            #region Arrange

            IEnumerable<DespesaDominio> expected = new List<DespesaDominio>()
            {
                new Mock<DespesaDominio>().Object
            };

            _despesaRepositoryMock = new Mock<IDespesaRepository>();
            _despesaRepositoryMock
                .Setup(d => d.BuscarTodasDespesas())
                .ReturnsAsync(expected);

            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.BuscarDespesas(null);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        #endregion

        #region AtualizarDespesa

        [Fact]
        public async void AtualizarDespesas_SemErros_RetornaDespesaDominio()
        {
            #region Arrange

            var expected = new Mock<DespesaDominio>().SetupAllProperties()
                .Object;
            expected.Descricao = "descricao";


            _despesaRepositoryMock = new Mock<IDespesaRepository>();
            _despesaRepositoryMock
                .Setup(d => d.AtualizarReceita(expected))
                .ReturnsAsync(expected);
            _despesaRepositoryMock
                .Setup(d => d.VerificarDespesaMes(expected))
                .Returns(Task.FromResult<DespesaDominio>(null));

            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.AtualizarDespesa(expected, 1);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion

        }
        [Fact]
        public async void AtualizarDespesas_CadastroRepetido_RetornaNulo()
        {
            #region Arrange

            var despesaDominio = new Mock<DespesaDominio>().SetupAllProperties()
                .Object;
            despesaDominio.Descricao = "descricao";


            _despesaRepositoryMock = new Mock<IDespesaRepository>();
            _despesaRepositoryMock
                .Setup(d => d.VerificarDespesaMes(despesaDominio))
                .Returns(Task.FromResult(despesaDominio));

            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.AtualizarDespesa(despesaDominio, 1);

            #endregion

            #region Assert

            DespesaDominio expected = null;

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        [Fact]
        public async void AtualizarDespesas_SemDescricao_RetornaNulo()
        {
            #region Arrange

            var despesaDominio = new Mock<DespesaDominio>()
                .SetupAllProperties()
                .Object;
            despesaDominio.Descricao = "";
            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.AtualizarDespesa(despesaDominio, 1);

            #endregion

            #region Assert

            DespesaDominio expected = null;

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        [Fact]
        public async void AtualizarDespesas_SemDespesaDominio_RetornaNulo()
        {
            #region Arrange

            DespesaDominio expected = null;

            #endregion

            #region Act

            var despesaService = obterDespesaService();
            var actual = await despesaService.AtualizarDespesa(expected, 1);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        #endregion

        public DespesaService obterDespesaService()
        {
            return new DespesaService(_despesaRepositoryMock?.Object);
        }
    }
}
