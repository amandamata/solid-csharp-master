using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Interfaces
{
    public interface IAdminService
    {
        void Add(Leilao auction);
        void Update(Leilao auction);
        void Remove(Leilao auction);
        IEnumerable<Categoria> SearchCategories();
        IEnumerable<Leilao> SearchAuctions();
        Leilao SearchById(int id);
        void StartTradingById(int id);
        void EndTradingById(int id);
    }
}
