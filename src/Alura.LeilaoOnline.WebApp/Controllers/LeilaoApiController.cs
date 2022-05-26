using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        private readonly IAuctionsDao _auctionsDao;
        public LeilaoApiController(IAuctionsDao auctionsDao)
        {
            _auctionsDao = auctionsDao;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _auctionsDao.SearchAuctions();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _auctionsDao.SearchById(id);
            if (leilao == null)
                return NotFound();
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _auctionsDao.Add(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _auctionsDao.Update(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _auctionsDao.SearchById(id);
            if (leilao == null)
                return NotFound();
            _auctionsDao.Remove(leilao);
            return NoContent();
        }
    }
}
