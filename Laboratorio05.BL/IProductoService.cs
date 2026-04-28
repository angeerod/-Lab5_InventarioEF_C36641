using Laboratorio05.Models;

namespace Laboratorio05.BL
{
    public interface IProductoService
    {
        IEnumerable<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
        void Agregar(Producto producto);
        void Actualizar(Producto producto);
        void Eliminar(int id);
    }
}
