using Laboratorio05.DA;
using Laboratorio05.Models;

namespace Laboratorio05.BL
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Producto? ObtenerPorId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor que 0", nameof(id));
            }
            return _repository.ObtenerPorId(id);
        }

        public void Agregar(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            producto.FechaIngreso = DateTime.Now;
            _repository.Agregar(producto);
        }

        public void Actualizar(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            if (producto.Id <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor que 0", nameof(producto.Id));
            }

            var productoExistente = _repository.ObtenerPorId(producto.Id);
            if (productoExistente == null)
            {
                throw new InvalidOperationException($"El producto con ID {producto.Id} no existe");
            }

            _repository.Actualizar(producto);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor que 0", nameof(id));
            }

            var producto = _repository.ObtenerPorId(id);
            if (producto == null)
            {
                throw new InvalidOperationException($"El producto con ID {id} no existe");
            }

            _repository.Eliminar(id);
        }
    }
}
