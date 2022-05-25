using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class LeilaoController : Controller
    {

        AppDbContext _context;

        public LeilaoController()
        {
            _context = new AppDbContext();
        }

        private IEnumerable<Categoria> SearchCategories()
            => _context.Categorias.ToList();

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

        public IActionResult Index()
        {
            var leiloes = SearchAuctions();
            return View(leiloes);
        } 

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = SearchCategories();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Leilao model)
        {
            if (ModelState.IsValid)
            {
                Add(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = SearchCategories();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = SearchCategories();
            ViewData["Operacao"] = "Edição";
            var leilao = SearchById(id);
            if (leilao == null) return NotFound();
            return View("Form", leilao);
        }

        [HttpPost]
        public IActionResult Edit(Leilao model)
        {
            if (ModelState.IsValid)
            {
                Update(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = SearchCategories();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var leilao = SearchById(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Rascunho) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Pregao;
            leilao.Inicio = DateTime.Now;
            Update(leilao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var leilao = SearchById(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Pregao) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Finalizado;
            leilao.Termino = DateTime.Now;
            Update(leilao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var leilao = SearchById(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao == SituacaoLeilao.Pregao) return StatusCode(405);
            Remove(leilao);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = SearchAuctions()
                    .Where(l => string.IsNullOrWhiteSpace(termo) || 
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) || 
                    l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", leiloes);
        }
    }
}
