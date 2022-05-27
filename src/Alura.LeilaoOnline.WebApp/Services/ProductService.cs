using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Leilao> SearchAudictionByTerm(string term)
        {
            throw new NotImplementedException();
        }

        public Categoria SearchCategoriesByIdWithAudictionInTrading(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaComInfoLeilao> SearchCategoriesCountByAudictionsInTrading()
        {
            throw new NotImplementedException();
        }
    }
}
