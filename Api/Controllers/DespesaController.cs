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
            var resultado = await _despesaService.CadastrarDespesa(_mapper.Map<DespesaDominio>(despesaDto));

            if (resultado != null) return Ok(_mapper.Map<DespesaDto>(resultado));
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DespesaDto>>> BuscarTodasDespesas()
        {
            var resultados = await _despesaService.BuscarTodasDespesas();
            return Ok(_mapper.Map<IEnumerable<DespesaDto>>(resultados));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DespesaDto>> BuscarDespesa(long id)
        {
            var resultado = await _despesaService.BuscarDespesa(id);
            return Ok(_mapper.Map<DespesaDto>(resultado));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DespesaDto>> AtualizarReceita([FromBody] DespesaDto despesaDto,
            long id)
        {
            var resultado = await _despesaService.AtualizarDespesa(_mapper.Map<DespesaDominio>(despesaDto)
                , id);
            if (resultado != null) return Ok(_mapper.Map<DespesaDto>(resultado));
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ExcluirDespesa(long id)
        {
            var resultado = await _despesaService.ExcluirDespesa(id);
            if (resultado) return Ok(resultado);
            return BadRequest();
        }
    }
}
