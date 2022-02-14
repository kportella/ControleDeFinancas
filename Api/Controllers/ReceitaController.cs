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

        public ReceitaController(IReceitaService receitaService, IMapper mapper)
        {
            _receitaService = receitaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ReceitaDto>> CadastroReceitas([FromBody] ReceitaDto receitaDto)
        {
            var resultado = await _receitaService.CadastroReceita(_mapper.Map<ReceitaDominio>(receitaDto));

            if (resultado != null) return Ok(_mapper.Map<ReceitaDto>(resultado));
            return BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceitaDto>>> BuscarTodasReceitas()
        {
            var resultados = await _receitaService.BuscarTodasReceitas();
            return Ok(_mapper.Map<IEnumerable<ReceitaDto>>(resultados));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceitaDto>> BuscarReceita(long id)
        {
            var resultado = await _receitaService.BuscarReceita(id);
            return Ok(_mapper.Map<ReceitaDto>(resultado));
        }
    }
}
