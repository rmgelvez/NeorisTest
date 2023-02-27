using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeorisTest.Dtos;

namespace NeorisTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MovimientoDto>>> Get()
        {
            var Movimientos = await _unitOfWork.Movimientos.GetAllAsync();
            return Ok(Movimientos);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovimientoDto>> Get(int id)
        {
            var Movimiento = await _unitOfWork.Movimientos.GetByIdAsync(id);
            if (Movimiento == null)
                return NotFound();

            return _mapper.Map<MovimientoDto>(Movimiento);
        }

        //POST: api/Movimientos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovimientoAddUpdateDto>> Post([FromBody] MovimientoAddUpdateDto MovimientoDto)
        {
            Movimiento movimiento = new Movimiento()
            {
                Valor = MovimientoDto.Valor,
                FechaMovimiento = MovimientoDto.FechaMovimiento,
                TipoMovimiento = MovimientoDto.Valor > 0 ? "Deposito" : "Retiro"
            };

            Cuenta cuenta = _unitOfWork.Cuentas.Find(s => s.NumeroCuenta == MovimientoDto.NumeroCuenta).FirstOrDefault();

            cuenta.SaldoInicial += MovimientoDto.Valor;

            if(cuenta.SaldoInicial < 0)
            {
                return BadRequest("Saldo no disponible");
            }

            movimiento.Cuenta = cuenta;
            movimiento.Saldo = cuenta.SaldoInicial;

            _unitOfWork.Cuentas.Update(cuenta);
            _unitOfWork.Movimientos.Add(movimiento);

            await _unitOfWork.saveAsync();

            if (movimiento == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = movimiento.Id }, MovimientoDto);
        }


        //PUT: api/Movimientos/4
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovimientoAddUpdateDto>> Put(int id, [FromBody] MovimientoAddUpdateDto MovimientoDto)
        {
            if (MovimientoDto == null)
                return NotFound();

            var Movimiento = _mapper.Map<Movimiento>(MovimientoDto);
            _unitOfWork.Movimientos.Update(Movimiento);
            await _unitOfWork.saveAsync();
            return MovimientoDto;
        }

        //DELETE: api/Movimientos
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Movimiento = await _unitOfWork.Movimientos.GetByIdAsync(id);
            if (Movimiento == null)
                return NotFound();

            _unitOfWork.Movimientos.Remove(Movimiento);
            await _unitOfWork.saveAsync();

            return NoContent();
        }

    }
}
