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
    public class ReceitaTeste
    {
        private Mock<IReceitaRepository> _ReceitaRepositoryMock;

        #region CadastrarReceita

        [Fact]
        public async void CadastrarReceita_SemErros_RetornaReceitaDominio()
        {
            #region Arrange

            var expected = new Mock<ReceitaDominio>().SetupAllProperties()
                .Object;
            expected.Descricao = "descricao";


            _ReceitaRepositoryMock = new Mock<IReceitaRepository>();
            _ReceitaRepositoryMock
                .Setup(d => d.CadastrarReceita(expected))
                .ReturnsAsync(expected);
            _ReceitaRepositoryMock
                .Setup(d => d.VerificarReceitaMes(expected))
                .Returns(Task.FromResult<ReceitaDominio>(null));

            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.CadastrarReceita(expected);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion

        }
        [Fact]
        public async void CadastrarReceita_CadastroRepetido_RetornaNulo()
        {
            #region Arrange

            var ReceitaDominio = new Mock<ReceitaDominio>().SetupAllProperties()
                .Object;
            ReceitaDominio.Descricao = "descricao";


            _ReceitaRepositoryMock = new Mock<IReceitaRepository>();
            _ReceitaRepositoryMock
                .Setup(d => d.VerificarReceitaMes(ReceitaDominio))
                .Returns(Task.FromResult(ReceitaDominio));

            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.CadastrarReceita(ReceitaDominio);

            #endregion

            #region Assert

            ReceitaDominio expected = null;

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        [Fact]
        public async void CadastrarReceita_SemDescricao_RetornaNulo()
        {
            #region Arrange

            var ReceitaDominio = new Mock<ReceitaDominio>()
                .SetupAllProperties()
                .Object;
            ReceitaDominio.Descricao = "";
            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.CadastrarReceita(ReceitaDominio);

            #endregion

            #region Assert

            ReceitaDominio expected = null;

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        [Fact]
        public async void CadastrarReceita_SemReceitaDominio_RetornaNulo()
        {
            #region Arrange

            ReceitaDominio expected = null;

            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.CadastrarReceita(expected);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        #endregion


        #region BuscarReceitas

        [Fact]
        public async void BuscarReceitas_ComDescricao_RetornaReceita()
        {
            #region Arrange

            var descricao = "descricao";
            IEnumerable<ReceitaDominio> expected = new List<ReceitaDominio>()
            {
                new Mock<ReceitaDominio>().Object
            };

            _ReceitaRepositoryMock = new Mock<IReceitaRepository>();
            _ReceitaRepositoryMock
                .Setup(d => d.BuscarReceitasPorDescricao(descricao))
                .ReturnsAsync(expected);

            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.BuscarReceitas(descricao);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion

        }

        [Fact]
        public async void BuscarReceitas_SemDescricao_RetornaReceita()
        {
            #region Arrange

            IEnumerable<ReceitaDominio> expected = new List<ReceitaDominio>()
            {
                new Mock<ReceitaDominio>().Object
            };

            _ReceitaRepositoryMock = new Mock<IReceitaRepository>();
            _ReceitaRepositoryMock
                .Setup(d => d.BuscarTodasReceitas())
                .ReturnsAsync(expected);

            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.BuscarReceitas(null);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        #endregion

        #region AtualizarReceita

        [Fact]
        public async void AtualizarReceitas_SemErros_RetornaReceitaDominio()
        {
            #region Arrange

            var expected = new Mock<ReceitaDominio>().SetupAllProperties()
                .Object;
            expected.Descricao = "descricao";


            _ReceitaRepositoryMock = new Mock<IReceitaRepository>();
            _ReceitaRepositoryMock
                .Setup(d => d.AtualizarReceita(expected))
                .ReturnsAsync(expected);
            _ReceitaRepositoryMock
                .Setup(d => d.VerificarReceitaMes(expected))
                .Returns(Task.FromResult<ReceitaDominio>(null));

            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.AtualizarReceita(expected, 1);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion

        }
        [Fact]
        public async void AtualizarReceitas_CadastroRepetido_RetornaNulo()
        {
            #region Arrange

            var ReceitaDominio = new Mock<ReceitaDominio>().SetupAllProperties()
                .Object;
            ReceitaDominio.Descricao = "descricao";


            _ReceitaRepositoryMock = new Mock<IReceitaRepository>();
            _ReceitaRepositoryMock
                .Setup(d => d.VerificarReceitaMes(ReceitaDominio))
                .Returns(Task.FromResult(ReceitaDominio));

            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.AtualizarReceita(ReceitaDominio, 1);

            #endregion

            #region Assert

            ReceitaDominio expected = null;

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        [Fact]
        public async void AtualizarReceitas_SemDescricao_RetornaNulo()
        {
            #region Arrange

            var ReceitaDominio = new Mock<ReceitaDominio>()
                .SetupAllProperties()
                .Object;
            ReceitaDominio.Descricao = "";
            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.AtualizarReceita(ReceitaDominio, 1);

            #endregion

            #region Assert

            ReceitaDominio expected = null;

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        [Fact]
        public async void AtualizarReceitas_SemReceitaDominio_RetornaNulo()
        {
            #region Arrange

            ReceitaDominio expected = null;

            #endregion

            #region Act

            var ReceitaService = obterReceitaService();
            var actual = await ReceitaService.AtualizarReceita(expected, 1);

            #endregion

            #region Assert

            actual.Should().BeEquivalentTo(expected);

            #endregion
        }

        #endregion

        public ReceitaService obterReceitaService()
        {
            return new ReceitaService(_ReceitaRepositoryMock?.Object);
        }
    }
}
