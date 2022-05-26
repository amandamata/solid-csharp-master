using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces
{
    public interface IAuctionsDao
    {
        IEnumerable<Categoria> SearchCategories();

        IEnumerable<Leilao> SearchAuctions();

        Leilao SearchById(int id);

        void Add(Leilao auction);

        void Update(Leilao auction);

        void Remove(Leilao auction);
    }
}
