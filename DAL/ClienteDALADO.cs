using EL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDALADO
    {
        /**
         * Array, ArrayList, Stack, Queue, List
         **/

        // una método para obtener todos los clientes
        public List<Cliente> GetClientes() 
        {
            // nota: Crear un listado de clientes
            List<Cliente> clientes = new List<Cliente>();

            // 1. Utilizar la clase SqlConnection
            SqlConnection conn = new SqlConnection(Connection.connectionString);

            try
            {
                // 2. Crear la consulta
                string query = "SELECT * FROM Clientes";

                // 3. Crear nuestro comando a ejecutar
                SqlCommand cmd = new SqlCommand(query, conn);

                // 4. Paso abrir la conexión hacia la base de datos
                conn.Open();

                // 5. Ejecutar el comando y almacenar el resultado
                SqlDataReader reader = cmd.ExecuteReader();

                // 6. Manejar la información
                while (reader.Read())
                {
                    // 6.1 Crear nuestro objeto Cliente
                    Cliente cliente = new Cliente()
                    {
                        ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                        Nombres = reader.GetString(reader.GetOrdinal("Nombres")),
                        Apellidos = reader.GetString(reader.GetOrdinal("Apellidos")),
                        Documento = reader.GetString(reader.GetOrdinal("Documento")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                        FechaRegistro = reader.GetDateTime(reader.GetOrdinal("FechaRegistro"))
                    };

                    // 6.2 Almacenar el objeto Cliente en la Lista de Clientes
                    clientes.Add(cliente);
                }

                // 7. Cerrar el reader

                reader.Close();

                // 8. Cerrar la conexión
                conn.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return clientes;
        }

        public int Guardar(Cliente cliente) //
        {
            int resultado = 0;
            SqlConnection conn = new SqlConnection(Connection.connectionString);


            try
            {
                string query = @"
                        INSERT INTO [dbo].[Clientes]
                               ([Nombres]
                               ,[Apellidos]
                               ,[Documento]
                               ,[Email]
                               ,[Telefono]
                               ,[FechaRegistro])
                         VALUES(
                               @Nombres
                               ,@Apellidos
                               ,@Documento
                               ,@Email
                               ,@Telefono
                               ,@FechaRegistro)
                    ";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Documento", cliente.Documento);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@FechaRegistro", cliente.FechaRegistro);

                conn.Open();

                resultado = cmd.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                resultado = -1;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return resultado;
        }

    }
}
