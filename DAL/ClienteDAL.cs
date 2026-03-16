using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL
    {
        // instancia de nuestro DbContext

        BancoDbContext _db;

        // metodo para guardar y actualizar un cliente

        public int Guardar(Cliente cliente, int id = 0, bool esEdicion = false)
        {
            // variable resultado
            int resultado = 0;

            // inicializar nuestro DbContext
            _db = new BancoDbContext();

            // validar si es una edicion
            if (esEdicion) 
            {
                // asociar el parametro id a la propiedad ClienteId del objeto Cliente
                cliente.ClienteId = id;

                _db.Entry(cliente).State = System.Data.Entity.EntityState.Modified; // UPDATE CLIENTE SET .... WHERE ID = ?
                _db.SaveChanges();
            }
            else
            {
                _db.Clientes.Add(cliente); // INSERT INTO CLIENTES(...) VALUES(?,?...)
                _db.SaveChanges();
            }

            resultado = cliente.ClienteId;

            // devolver el resultado
            return resultado;
        }

        // metodo para mostrar un listado de cliente
        public List<Cliente> ObtenerClientes()
        {
            // inicializar nuestro DbContext
            _db = new BancoDbContext();

            return _db.Clientes.ToList(); // SELECT * FROM Clientes
        }

        // metodo para eliminar un cliente
        public int Eliminar(Cliente cliente)
        {
            int resultado = 0;

            // inicializar nuestro DbContext
            _db = new BancoDbContext();

            _db.Clientes.Remove(cliente); // DELETE FROM Clientes Where Id = ?
            _db.SaveChanges();

            resultado = cliente.ClienteId;

            return resultado;
        }
    }
}
