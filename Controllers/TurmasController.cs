using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using escola.Models;

namespace escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly EscolaContext _context;

        public TurmasController(EscolaContext context)
        {
            _context = context;
        }

        // GET: api/Turmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
          if (_context.Turmas == null)
          {
              return NotFound();
          }          
            return await _context.Turmas.ToListAsync();
        }

        // GET: api/Turmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
          if (_context.Turmas == null)
          {
              return NotFound();
          }
            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            return turma;
        }

        // PUT: api/Turmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, Turma turma)
        {
            if (id != turma.Id)
            {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Turmas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
          if (_context.Turmas == null)
          {
              return Problem("Nenhuma turma foi informada.");
          }
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurma", new { id = turma.Id }, turma);
        }

        // DELETE: api/Turmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }
            var turma = await _context.Turmas.FindAsync(id);
            var aluno = await _context.Alunos.ToListAsync();
            if (turma == null)
            {
                return NotFound();
            }

            foreach(Aluno alunos in aluno)
            {
                if(turma.Id == alunos.Id)
                {
                    return Content("Turma não pode ser deletada");
                }
            }
            
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool TurmaExists(int id)
        {
            return (_context.Turmas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
