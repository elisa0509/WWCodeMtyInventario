using Inventario.Negocio.POCO;
using Inventario.Negocio.Repositorios.Interfaces;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Negocio.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly IDatabase _database;

        public CategoriaRepositorio(IDatabase database)
        {
            _database = database;
        }
        public async Task Editar(Categoria categoria)
        {
            await _database.UpdateAsync(categoria);
        }

        public async Task Agregar(Categoria categoria)
        {
            await _database.InsertAsync<Categoria>(categoria);
        }

        public Task Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> PorId(int id)
        {
            return _database.FirstOrDefaultAsync<Categoria>("SELECT * FROM Categoria Where Id = @0", id);
        }

        public async Task<List<Categoria>> Todos()
        {
            return await _database.FetchAsync<Categoria>();
        }
        public Task<Categoria> PorNombre(string nombre)
        {
            return _database.FirstOrDefaultAsync<Categoria>("SELECT * FROM Categoria Where Nombre = @0", nombre);
        }
    }
}
