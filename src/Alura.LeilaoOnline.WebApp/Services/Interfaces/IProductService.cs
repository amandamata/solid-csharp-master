using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Leilao> SearchAudictionByTerm(string term);
        IEnumerable<CategoriaComInfoLeilao> SearchCategoriesCountByAudictionsInTrading();
        Categoria SearchCategoriesByIdWithAudictionInTrading(int id);
    }
}
