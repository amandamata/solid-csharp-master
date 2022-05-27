using Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public class AdminServiceLogicExclusion : IAdminService
    {
        private readonly IAdminService _adminService;

        public AdminServiceLogicExclusion(IAuctionsDao auctionsDao, ICategoriesDao categoriesDao)
        {
            _adminService = new AdminService(auctionsDao, categoriesDao);
        }

        public void Add(Leilao auction)
        {
            _adminService.Add(auction);
        }

        public void Update(Leilao auction)
        {
            _adminService.Update(auction);
        }

        public void Remove(Leilao auction)
        {
            if (auction != null && auction.Situacao != SituacaoLeilao.Pregao)
            {
                auction.Situacao = SituacaoLeilao.Arquivado;
                _adminService.Remove(auction);
            }
        }

        public Leilao SearchById(int id)
        {
            return _adminService.SearchById(id);
        }

        public IEnumerable<Leilao> SearchAuctions()
        {
            return _adminService.SearchAuctions().Where(a => a.Situacao != SituacaoLeilao.Arquivado);
        }

        public IEnumerable<Categoria> SearchCategories()
        {
            return _adminService.SearchCategories();
        }

        public void StartTradingById(int id)
        {
            _adminService.StartTradingById(id);
        }

        public void EndTradingById(int id)
        {
            _adminService.EndTradingById(id);
        }
    }
}
