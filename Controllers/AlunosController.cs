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
    public class AlunosController : ControllerBase
    {
        private readonly EscolaContext _context;

        public AlunosController(EscolaContext context)
        {
            _context = context;
        }

        // GET: swagger/Alunos/
        [HttpGet]
        public async Task<JsonResult> GetAlunos()
        {
            if (_context.Alunos == null || _context.Alunos.Count() == 0)
                return new JsonResult("Não há nenhum aluno cadastrado.");

            var alunos = await _context.Alunos.ToListAsync();

            return new JsonResult(new
            {
                total = alunos.Count,
                alunos = alunos
            });
        }

        // GET: swagger/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {

            if (_context.Alunos == null || _context.Alunos.Count() == 0)
            {
                return NotFound("Não há nenhum aluno cadastrado.");
            }
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound($"A busca não retornou resultados para o aluno de ID: {id}.");
            }

            return aluno;
        }

        // POST: swagger/Alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public JsonResult PostAluno()
        {
            var alunoExemplo = new
            {
                mensagem = "A rota para adicionar um aluno é swagger/aluno/add",
                formato = new
                {
                    Nome = "Nome Exemplo",
                    Apelido = "Apelido Exemplo - Pode ser omitido",
                    EmailPrincipal = "exemplo@domain.com",
                    Sexo = "Enviar uma das seguintes letras: F - Feminino, M - Masculino, 0 - Outros, N - Não Informado",
                    DataNascimento = "Enviar no formado: YYYY-MM-DD (Ano com 4 dígitos, mês com dois dígitos, dia com um dígito)"
                }
            };

            return new JsonResult(alunoExemplo);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            var listErrors = new List<string>();
            string response = "";

            if (_context.Alunos == null)
                return Ok("Nenhum aluno foi informado!");

            try
            {
                if (_context.Alunos != null)
                {
                    if (aluno.Nome == string.Empty)
                        listErrors.Add("O nome para o aluno está ausente!");
                                       
                    response = JsonSerializer.Serialize(listErrors);

                    if (listErrors.Count <= 0)
                    {
                        if (!AlunoExists(aluno))
                        {
                            _context.Alunos.Add(aluno);
                            await _context.SaveChangesAsync();
                            response = JsonSerializer.Serialize(aluno);
                        }
                        else
                        {
                            response = "Este aluno já está na escola!";
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

        private bool AlunoExists(int id)
        {
            return (_context.Alunos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool AlunoExists(Aluno aluno)
        {
            return _context.Alunos.Any(c => c.Nome == aluno.Nome
            && c.DataNascimento == aluno.DataNascimento);
        }

        // PUT: swagger/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutAluno(Aluno aluno)
        {
            if (aluno.Id <= 0)
            {
                return BadRequest("Nenhum id informado para alteração");
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(aluno.Id))
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

        // DELETE: swagger/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if (_context.Alunos == null)
            {
                return NotFound("Não há nenhum aluno cadastrado");
            }
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound($"O id: {id} não existe na base de dados.");
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok("O registro foi removido com sucesso!");
        }
    }
}