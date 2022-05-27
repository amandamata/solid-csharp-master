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
        private readonly ICategoriesDao _categoriesDao;


        public AdminService(IAuctionsDao auctionsDao, ICategoriesDao categoriesDao)
        {
            _auctionsDao = auctionsDao;
            _categoriesDao = categoriesDao;
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
            return _auctionsDao.GetById(id);
        }

        public IEnumerable<Leilao> SearchAuctions()
        {
            return _auctionsDao.GetAll();
        }

        public IEnumerable<Categoria> SearchCategories()
        {
            return _categoriesDao.GetAll();
        }

        public void StartTradingById(int id)
        {
            var auction = _auctionsDao.GetById(id);
            if (auction != null && auction.Situacao == SituacaoLeilao.Rascunho)
            {
                auction.Situacao = SituacaoLeilao.Pregao;
                auction.Inicio = DateTime.Now;
                _auctionsDao.Update(auction);
            }
        }

        public void EndTradingById(int id)
        {
            var auction = _auctionsDao.GetById(id);
            if (auction != null && auction.Situacao == SituacaoLeilao.Pregao)
            {
                auction.Situacao = SituacaoLeilao.Finalizado;
                auction.Termino = DateTime.Now;
                _auctionsDao.Update(auction);
            }
        }
    }
}
