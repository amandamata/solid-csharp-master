using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class AuctionsDao : IAuctionsDao
    {
        private readonly AppDbContext _appDbContext;

        public AuctionsDao()
        {
            _appDbContext = new AppDbContext();
        }

        public IEnumerable<Leilao> GetAll()
        {
            return _appDbContext.Leiloes.Include(l => l.Categoria).ToList();
        }

        public Leilao GetById(int id)
        {
            return _appDbContext.Leiloes.First(l => l.Id == id);
        }

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
