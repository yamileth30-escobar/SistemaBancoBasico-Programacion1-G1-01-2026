using BLL;
using Dapper;
using EL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUI
{
    internal class Program
    {
        // instancia de la clase ClienteBLL
        private static ClienteBLL _clienteBLL;

        static void Main(string[] args)
        {
            // menu

            do
            {
                Console.WriteLine("Ingresa una opcion:");
                Console.WriteLine("1. Insertar un cliente\n2. Mostrar listado de clientes\n3. Mostrar listado de clientes a traves de Dapper\n0. Salir");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("Hasta pronto! ....");
                            return;
                        case 1:
                            GuardarCliente();
                            break;
                        case 2:
                            MostrarClientes();
                            break;
                        case 3:
                            MostrarClientesUsandoDapper();
                            break;
                        default:
                            break;
                    }
                }

            } while (true);
        }

        private static void MostrarClientesUsandoDapper()
        {
            try
            {
                // cadena de conexion
                string connectionString = "Data Source=YAMILETH-ESCOBA\\SQLExpress;Initial Catalog=Banco_BD_G1;Integrated Security=True;";

                // crear un objeto SqlConnection
                SqlConnection conn = new SqlConnection(connectionString);

                // crear el query a ejecutar
                string query = "SELECT * FROM Clientes";

                // ejecutar la consulta y almacenar la informacion
                conn.Open();

                var listado = conn.Query<Cliente>(query);

                conn.Close();

                foreach (var item in listado)
                {
                    Console.WriteLine($"Id: {item.ClienteId}\nNombre: {item.Nombres} {item.Apellidos}\nDocumento de Identidad: {item.Documento}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void MostrarClientes()
        {
            // inicializar la instancia de la clase ClienteBLL
            _clienteBLL = new ClienteBLL();

            // almacenar el listado
            var listado = _clienteBLL.Mostrar();

            // recorrer el listado y mostrar la informacion

            foreach (var item in listado)
            {
                Console.WriteLine($"Id: {item.ClienteId}\nNombre: {item.Nombres} {item.Apellidos}\nDocumento de Identidad: {item.Documento}");
            }
        }

        private static void GuardarCliente()
        {
            // crear un objeto cliente vacio
            Cliente cliente = new Cliente();

            Console.Write("Ingresa los nombres: ");
            cliente.Nombres = Console.ReadLine();

            Console.Write("Ingresa los apellidos: ");
            cliente.Apellidos = Console.ReadLine();

            Console.Write("Ingresa el documento: ");
            cliente.Documento = Console.ReadLine().Trim().Replace("-","");

            Console.Write("Ingresa el correo electronico: ");
            cliente.Email = Console.ReadLine();

            Console.Write("Ingresa el numero de telefono: ");
            cliente.Telefono = Console.ReadLine();

            cliente.FechaRegistro = DateTime.Now;

            // incializamos la instancia de la clase ClienteBLL
            _clienteBLL = new ClienteBLL();

            // guardar el cliente
            int resultado = _clienteBLL.Guardar(cliente);

            if (resultado > 0)
            {
                Console.WriteLine("Cliente almacenado con exito!");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al guardar el cliente!");
            }
        }
    }
}
