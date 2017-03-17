namespace PruebaEntradaGAP.Dominio.Interfaces
{
    public interface IRepositorio<T> : ICrear<T>, IConsultar<T>, IActualizar<T> where T : class
    {
        
    }
}