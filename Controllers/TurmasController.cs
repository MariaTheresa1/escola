using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using escola.Models;

namespace escola.Controllers
{
    [Route("swagger/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly EscolaContext _context;

        public TurmasController(EscolaContext context)
        {
            _context = context;
        }

        // GET: swagger/Turmas/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            if (_context.Turmas == null || _context.Turmas.Count() == 0)
            {
                return NotFound("Não há nenhuma turma cadastrada.");
            }
            return await _context.Turmas.ToListAsync();
        }

        // GET: swagger/Turmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {

            if (_context.Turmas == null || _context.Turmas.Count() == 0)
            {
                return NotFound("Não há nenhuma turma cadastrada.");
            }
            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null)
            {
                return NotFound($"A busca não retornou resultados para o turma de ID: {id}.");
            }

            return turma;
        }

        // POST: swagger/Turmas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public JsonResult PostTurma()
        {
            var turmaExemplo = new
            {
                mensagem = "A rota para adicionar um turma é swagger/turma/add",
                formato = new
                {
                    Nome = "Nome Exemplo",
                    Ativo = "0 ou 1 - true ou false"                    
                }
            };

            return new JsonResult(turmaExemplo);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
            var listErrors = new List<string>();
            string response = "";

            try
            {
                if (_context.Turmas == null)
                {
                    if (turma.Nome == string.Empty)
                        listErrors.Add("O nome para a turma está ausente!");

                    response = JsonSerializer.Serialize(listErrors);
                }
                else if (!TurmaExists(turma.Id))
                {
                    _context.Turmas.Add(turma);
                    await _context.SaveChangesAsync();
                    response = JsonSerializer.Serialize(turma);
                }
                else
                {
                    response = "Este turma já está na escola!";
                }
            }
            catch (Exception ex)
            {
                response = JsonSerializer.Serialize(ex.Message);
            }

            return CreatedAtAction(nameof(GetTurma), new { id = turma.Id }, response);
        }

        private bool TurmaExists(int id)
        {
            return (_context.Turmas?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // PUT: swagger/Turmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutTurma(Turma turma)
        {
            if (turma.Id <= 0)
            {
                return BadRequest("Nenhum id informado para alteração");
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(turma.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Alteração realizada com sucesso!");
        }

        // DELETE: swagger/Turmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            if (_context.Turmas == null)
            {
                return NotFound("Não há nenhuma turma cadastrada");
            }
            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null)
            {
                return NotFound($"O id: {id} não existe na base de dados.");
            }

            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();

            return Ok("O registro foi removido com sucesso!");
        }
    }
}