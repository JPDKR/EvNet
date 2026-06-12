namespace EvNet.Domain.Interfaces
{
    interface IABM<T> where T : class
    {
        int Insertar(T obj);
        int Eliminar(int id);
        int Modificar(T obj);
        T Obtener(int id);
        List<T> ObtenerTodos();
    }
}
