using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaService _despesaService;
        private readonly IMapper _mapper;

        public DespesaController(IDespesaService despesaService, IMapper mapper)
        {
            _despesaService = despesaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<DespesaDto>> CadastrarDespesa([FromBody] DespesaDto despesaDto)
        {
            try
            {
                var resultado = await _despesaService.CadastrarDespesa(_mapper.Map<DespesaDominio>(despesaDto));

                if (resultado != null) return Ok(_mapper.Map<DespesaDto>(resultado));
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DespesaDto>>> BuscarDespesas(string? descricao)
        {
            try
            {
                var resultados = await _despesaService.BuscarDespesas(descricao);
                return Ok(_mapper.Map<IEnumerable<DespesaDto>>(resultados));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DespesaDto>> BuscarDespesa(long id)
        {
            try
            {
                var resultado = await _despesaService.BuscarDespesa(id);
                return Ok(_mapper.Map<DespesaDto>(resultado));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DespesaDto>> AtualizarReceita([FromBody] DespesaDto despesaDto,
            long id)
        {
            try
            {
                var resultado = await _despesaService.AtualizarDespesa(_mapper.Map<DespesaDominio>(despesaDto)
                    , id);
                if (resultado != null) return Ok(_mapper.Map<DespesaDto>(resultado));
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ExcluirDespesa(long id)
        {
            try
            {
                var resultado = await _despesaService.ExcluirDespesa(id);
                if (resultado) return Ok(resultado);
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }
    }
}
