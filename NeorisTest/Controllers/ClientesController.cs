using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeorisTest.Dtos;
using System.Diagnostics.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NeorisTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            var clientes = await _unitOfWork.Clientes.GetAllAsync();
            return Ok(clientes);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (cliente == null)
                return NotFound();

            return _mapper.Map<ClienteDto>(cliente);
        }

        //POST: api/Clientes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Post([FromBody] ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            _unitOfWork.Clientes.Add(cliente);

            await _unitOfWork.saveAsync();
            
            if (cliente == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = cliente.Id }, clienteDto);
        }


        //PUT: api/Clientes/4
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
                return NotFound();

            var clienteActualizar = _mapper.Map<Cliente>(clienteDto);
            clienteActualizar.Id = id;

            _unitOfWork.Clientes.Update(clienteActualizar);
            await _unitOfWork.saveAsync();
            return clienteDto;
        }

        //DELETE: api/Clientes
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (Cliente == null)
                return NotFound();

            _unitOfWork.Clientes.Remove(Cliente);
            await _unitOfWork.saveAsync();

            return NoContent();
        }
    }
}
