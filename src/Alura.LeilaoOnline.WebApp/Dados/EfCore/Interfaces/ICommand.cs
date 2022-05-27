namespace Alura.LeilaoOnline.WebApp.Dados.EfCore.Interfaces
{
    public interface ICommand<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
    }
}
