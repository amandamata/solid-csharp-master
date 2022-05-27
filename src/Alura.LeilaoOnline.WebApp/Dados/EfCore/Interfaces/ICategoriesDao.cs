using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces
{
    public interface ICategoriesDao
    {
        IEnumerable<Categoria> SearchCategories();
        Categoria SearchCategoriesById(int id);
    }
}
