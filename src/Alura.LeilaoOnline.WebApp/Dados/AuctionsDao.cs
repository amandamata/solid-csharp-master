using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class AuctionsDao
    {
        private readonly AppDbContext _appDbContext;

        public AuctionsDao()
        {
            _appDbContext = new AppDbContext();
        }

        public IEnumerable<Categoria> SearchCategories()
            => _appDbContext.Categorias.ToList();

        public IEnumerable<Leilao> SearchAuctions()
            => _appDbContext.Leiloes.Include(l => l.Categoria).ToList();

        public Leilao SearchById(int id)
            => _appDbContext.Leiloes.First(l => l.Id == id);

        public void Add(Leilao auction)
        {
            _appDbContext.Leiloes.Add(auction);
            _appDbContext.SaveChanges();
        }

        public void Update(Leilao auction)
        {
            _appDbContext.Leiloes.Update(auction);
            _appDbContext.SaveChanges();
        }

        public void Remove(Leilao auction)
        {
            _appDbContext.Leiloes.Remove(auction);
            _appDbContext.SaveChanges();
        }
    }
}
