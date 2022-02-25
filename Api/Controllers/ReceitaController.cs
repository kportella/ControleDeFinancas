using Aplicacao.Interfaces;
using Aplicacao.Dtos;
using AutoMapper;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaService _receitaService;
        private readonly IMapper _mapper;
        private readonly string Url = "https://localhost:7017/";

        public ReceitaController(IReceitaService receitaService, IMapper mapper)
        {
            _receitaService = receitaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ReceitaDto>> CadastrarReceita([FromBody] ReceitaDto receitaDto)
        {
            try
            {
                var resultado = await _receitaService.CadastrarReceita(_mapper.Map<ReceitaDominio>(receitaDto));

                if (resultado != null) return Created($"{Url}{receitaDto.Id}", _mapper.Map<ReceitaDto>(resultado));
                return BadRequest();
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceitaDto>>> BuscarReceitas(string? descricao)
        {
            try
            {
                var resultados = await _receitaService.BuscarReceitas(descricao);
                return Ok(_mapper.Map<IEnumerable<ReceitaDto>>(resultados));
            }
            catch (Exception)   
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceitaDto>> BuscarReceita(long id)
        {
            try
            {
                var resultado = await _receitaService.BuscarReceita(id);
                return Ok(_mapper.Map<ReceitaDto>(resultado));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReceitaDto>> AtualizarReceita([FromBody] ReceitaDto receitaDto,
            long id)
        {
            try
            {
                var resultado = await _receitaService.AtualizarReceita(_mapper.Map<ReceitaDominio>(receitaDto)
                    , id);
                if (resultado != null) return Ok(_mapper.Map<ReceitaDto>(resultado));
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ExcluirReceita(long id)
        {
            try
            {
                var resultado = await _receitaService.ExcluirReceita(id);
                if (resultado) return Ok(resultado);
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }
        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<IEnumerable<ReceitaDto>>> BuscarReceitasMes(int ano, int mes)
        {
            try
            {
                var resultados = await _receitaService.BuscarReceitasMes(ano, mes);
                return Ok(_mapper.Map<IEnumerable<ReceitaDto>>(resultados));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Tente novamente mais tarde.");
            }
        }
    }
}
