using AutoMapper;
using ExamesAPI.Data;
using ExamesAPI.Data.Dtos;
using ExamesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ExameController : ControllerBase
    {

        private ExameContext _context;
        private IMapper _mapper;

        public ExameController(ExameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpPost]
        public IActionResult AdicionarExame([FromBody] CreateExameDto exameDto)
        {
            Exames exame = _mapper.Map<Exames>(exameDto);

            _context.Exames.Add(exame);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarExamesPorId), new { Id = exame.Id }, exame);

        }

        [HttpGet]
        public IEnumerable<Exames> RecuperarExames()
        {
            return _context.Exames;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarExamesPorId(int id)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Exames exame = _context.Exames.FirstOrDefault(exame => exame.Id == id);
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (exame != null)
            {
                ReadExameDto exameDto = _mapper.Map<ReadExameDto>(exame);
                Ok(exame);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarExame(int id, [FromBody] UpdateExameDto exameDto)
        {
            Exames exame = _context.Exames.FirstOrDefault(exame => exame.Id == id);
            if (exame == null)
            {
                return NotFound();
            }
            _mapper.Map(exameDto, exame);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarExame(int id)
        {
            Exames exame = _context.Exames.FirstOrDefault(exame => exame.Id == id);
            if (exame == null)
            {
                return NotFound();
            }
            _context.Remove(exame);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}
