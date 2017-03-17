using System.Threading.Tasks;
using PruebaEntradaGAP.Dominio.Entidades;

namespace PruebaEntradaGAP.Dominio.Interfaces
{
    public interface ICrear<T> where T : class
    {
        Task<T> Crear(T Model);
    }
}