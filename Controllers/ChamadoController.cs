using ApiServico.Controllers.Filters;
using ApiServico.Controllers.Helpers;
using ApiServico.DataContexts;
using ApiServico.Models;
using ApiServico.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServico.Controllers
{
    [Route("/chamados")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChamadoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos([FromQuery] ChamadoFilter filter)
        {
            //var query = _context.Chamados.AsQueryable();

            //if(filter.Search is not null)
            //{
            //    query = query.Where(x => x.Titulo.Contains(filter.Search));
            //}

            //if(filter.Situacao is not null)
            //{
            //    query = query.Where(x => x.Status.Equals(filter.Situacao));
            //}

            //var (queryPaginated, response) = await Paginate<Chamado>.Set(query, filter);

            //response.Data = await queryPaginated.ToListAsync();

            //return Ok(response);
            //await ChamadoFilterSet.Set(_context.Chamados, filter)

            var result = await new ChamadoFilterSet().Set(_context.Chamados, filter);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var chamado = await _context.Chamados.FirstOrDefaultAsync(x => x.Id == id);

            if(chamado is null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ChamadoDto novoChamado)
        {
            var chamado = new Chamado() { Titulo = novoChamado.Titulo, Descricao = novoChamado.Descricao };

            await _context.Chamados.AddAsync(chamado);
            await _context.SaveChangesAsync();

            return Created("", chamado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ChamadoDto atualizacaoChamado)
        {
            var chamado = await _context.Chamados.FirstOrDefaultAsync(x => x.Id == id);

            if (chamado is null)
            {
                return NotFound();
            }

            chamado.Titulo = atualizacaoChamado.Titulo;
            chamado.Descricao = atualizacaoChamado.Descricao;

            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();

            return Ok(chamado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var chamado = await _context.Chamados.FirstOrDefaultAsync(x => x.Id == id);

            if (chamado is null)
            {
                return NotFound();
            }

            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
