using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumoController : ControllerBase
    {
        private readonly IResumoService _resumoService;
        private readonly IMapper _mapper;

        public ResumoController(IResumoService resumoService, IMapper mapper)
        {
            _resumoService = resumoService;
            _mapper = mapper;
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<ResumoDto>> BuscarResumoMes(int ano, int mes)
        {
            var resultado = await _resumoService.BuscarResumoMes(ano, mes);
            return Ok(_mapper.Map<ResumoDto>(resultado));
        }
    }
}
