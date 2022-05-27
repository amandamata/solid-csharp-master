using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces
{
    public interface IQuery<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
