using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces
{
    public interface IAuctionsDao : ICommand<Leilao>, IQuery<Leilao>
    {
       
    }
}
