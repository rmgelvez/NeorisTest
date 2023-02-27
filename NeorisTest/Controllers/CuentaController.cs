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
    public class CuentaController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CuentaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CuentaDto>>> Get()
        {
            var cuentas = await _unitOfWork.Cuentas.GetAllAsync();
            return Ok(cuentas);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CuentaDto>> Get(int id)
        {
            var cuenta = await _unitOfWork.Cuentas.GetByIdAsync(id);
            if (cuenta == null)
                return NotFound();

            return _mapper.Map<CuentaDto>(cuenta);
        }

        //POST: api/cuentas
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CuentaAddUptadeDto>> Post([FromBody] CuentaAddUptadeDto cuentaAddUptadeDto)
        {
            var cuenta = _mapper.Map<Cuenta>(cuentaAddUptadeDto);

            _unitOfWork.Cuentas.Add(cuenta);

            await _unitOfWork.saveAsync();

            if (cuenta == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = cuenta.Id }, cuentaAddUptadeDto);
        }


        //PUT: api/cuentas/4
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CuentaAddUptadeDto>> Put(int id, [FromBody] CuentaAddUptadeDto cuentaDto)
        {
            if (cuentaDto == null)
                return NotFound();

            var cuenta = _mapper.Map<Cuenta>(cuentaDto);
            _unitOfWork.Cuentas.Update(cuenta);
            await _unitOfWork.saveAsync();
            return cuentaDto;
        }

        //DELETE: api/cuentas
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var cuenta = await _unitOfWork.Cuentas.GetByIdAsync(id);
            if (cuenta == null)
                return NotFound();

            _unitOfWork.Cuentas.Remove(cuenta);
            await _unitOfWork.saveAsync();

            return NoContent();
        }

    }
}
