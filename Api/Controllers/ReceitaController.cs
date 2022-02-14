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
    }
}
