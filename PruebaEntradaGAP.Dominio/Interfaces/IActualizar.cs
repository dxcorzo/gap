using System.Threading.Tasks;

namespace PruebaEntradaGAP.Dominio.Interfaces
{
    public interface IActualizar<T> where T: class
    {
        Task<T> Actualizar(T Model);
    }
}