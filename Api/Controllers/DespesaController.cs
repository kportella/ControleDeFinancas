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
    }
}
