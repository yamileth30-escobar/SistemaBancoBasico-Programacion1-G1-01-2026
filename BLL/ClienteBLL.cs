using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {
        // instancia de nuestra clase ClienteDAL
        public ClienteDAL _clienteDAL;

        // crear un metodo para almacenar un cliente
        public int Guardar(Cliente cliente)
        {

            // inicializar la instancia de ClienteDALADO
            _clienteDAL = new ClienteDAL();

            int resultado = _clienteDAL.Guardar(cliente);

            return resultado;
        }

        public List<Cliente> Mostrar()
        {
            // inicializar la instancia de ClienteDALADO
            _clienteDAL = new ClienteDAL();

            var listado = _clienteDAL.ObtenerClientes();

            return listado;
        }
    }
}
