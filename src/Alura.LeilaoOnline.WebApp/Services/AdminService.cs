using Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAuctionsDao _auctionsDao;

        public AdminService(IAuctionsDao auctionsDao)
        {
            _auctionsDao = auctionsDao;
        }

        public void Add(Leilao auction)
        {
            _auctionsDao.Add(auction);
        }

        public void Update(Leilao auction)
        {
            _auctionsDao.Update(auction);
        }

        public void Remove(Leilao auction)
        {
            if (auction != null && auction.Situacao != SituacaoLeilao.Pregao)
            {
                _auctionsDao.Remove(auction);
            }
        }

        public Leilao SearchById(int id)
        {
            return _auctionsDao.SearchById(id);
        }

        public IEnumerable<Leilao> SearchAuctions()
        {
            return _auctionsDao.SearchAuctions();
        }

        public IEnumerable<Categoria> SearchCategories()
        {
            return _auctionsDao.SearchCategories();
        }

        public void StartTradingById(int id)
        {
            var auction = _auctionsDao.SearchById(id);
            if (auction != null && auction.Situacao == SituacaoLeilao.Rascunho)
            {
                auction.Situacao = SituacaoLeilao.Pregao;
                auction.Inicio = DateTime.Now;
                _auctionsDao.Update(auction);
            }
        }

        public void EndTradingById(int id)
        {
            var auction = _auctionsDao.SearchById(id);
            if (auction != null && auction.Situacao == SituacaoLeilao.Pregao)
            {
                auction.Situacao = SituacaoLeilao.Finalizado;
                auction.Termino = DateTime.Now;
                _auctionsDao.Update(auction);
            }
        }
    }
}
