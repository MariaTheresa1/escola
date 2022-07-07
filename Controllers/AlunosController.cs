using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using escola.Models;
using System.Text.Json;

namespace escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly EscolaContext _context;

        public AlunosController(EscolaContext context)
        {
            _context = context;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }
            return await _context.Alunos.ToListAsync();
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            var listErrors = new List<string>(); 
            string response = ""; 
            if (_context.Alunos == null)
            {
                return Problem("Nenhum aluno foi informado.");
            }
            try 
            {
                if (_context.Alunos != null)
                {
                    if (aluno.TurmaId == 0)
                        listErrors.Add("Um aluno nao pode ser incluido sem uma turma.");

                    response = JsonSerializer.Serialize(listErrors);

                    if (listErrors.Count <= 0)
                    {
                        if (!AlunoExists(aluno.Id))
                        {
                            _context.Alunos.Add(aluno);
                            await _context.SaveChangesAsync();
                            response = JsonSerializer.Serialize(aluno);
                        }
                        else
                        {
                            response = "Esse aluno já foi cadastrado.";
                        }
                    }
                }
            } 
            catch (Exception ex) 
            {
                response = JsonSerializer.Serialize(ex.Message);
            } 

            return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, response);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return (_context.Alunos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
