using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        AppDbContext _context;

        public LeilaoApiController()
        {
            _context = new AppDbContext();
        }

        private IEnumerable<Leilao> SearchAuctions()
            => _context.Leiloes.Include(l => l.Categoria).ToList();

        private Leilao SearchById(int id)
            => _context.Leiloes.First(l => l.Id == id);

        private void Add(Leilao auction)
        {
            _context.Leiloes.Add(auction);
            _context.SaveChanges();
        }

        private void Update(Leilao auction)
        {
            _context.Leiloes.Update(auction);
            _context.SaveChanges();
        }

        private void Remove(Leilao auction)
        {
            _context.Leiloes.Remove(auction);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = SearchAuctions();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = SearchById(id);
            if (leilao == null)
                return NotFound();
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            Add(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            Update(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = SearchById(id);
            if (leilao == null)
                return NotFound();
            Remove(leilao);
            return NoContent();
        }
    }
}
