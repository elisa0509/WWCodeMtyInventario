using Inventario.Negocio.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Negocio.Repositorios.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Todos();
        Task<Categoria> PorId(int id);
        Task Agregar(Categoria categoria);
        Task Editar(Categoria categoria);
        Task Borrar(int id);
        Task<Categoria> PorNombre(string nombre);

    }
}
