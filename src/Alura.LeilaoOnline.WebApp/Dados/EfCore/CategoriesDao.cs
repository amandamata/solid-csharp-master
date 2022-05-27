using Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class CategoriesDao : ICategoriesDao
    {
        private readonly AppDbContext _appDbContext;
        public CategoriesDao(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _appDbContext.Categorias.Include(c => c.Leiloes);
        }

        public Categoria GetById(int id)
        {
            return _appDbContext.Categorias.Include(c => c.Leiloes).First(c => c.Id == id);
        }
    }
}
