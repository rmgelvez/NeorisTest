using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeorisTest.Dtos;

namespace NeorisTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReporteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{ClienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MovimientoDto>>> Get(int ClienteId, [FromQuery] DateTime fechaInicial, [FromQuery] DateTime fechaFinal)
        {
            var reporteMovimientos = await _unitOfWork.Movimientos.GetMovimientosBetweenDates(ClienteId, fechaInicial, fechaFinal);
            if (reporteMovimientos == null || reporteMovimientos.Count() == 0)
                return NotFound();
            return Ok(reporteMovimientos.Select(s => _mapper.Map<MovimientoDto>(s)));
        }
    }
}
