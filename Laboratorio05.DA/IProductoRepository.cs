using Laboratorio05.Models;

namespace Laboratorio05.DA
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
        void Agregar(Producto producto);
        void Actualizar(Producto producto);
        void Eliminar(int id);
    }
}

