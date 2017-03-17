using System;
using System.Collections.Generic;

namespace PruebaEntradaGAP.Dominio.Interfaces
{
    public interface IConsultar<out T> where T : class
    {
        IEnumerable<T> Consultar();
        T Consultar(int Id);
    }
}