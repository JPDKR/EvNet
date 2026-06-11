using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvNet.Data.Interfaces
{
    interface IABM<T> where T:class
    {
                int Insertar(T obj);
        int Eliminar(int id);
        int Modificar(T obj);
        T Obtener(int id);
        List<T> ObtenerTodos();
    }
}
