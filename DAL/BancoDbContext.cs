using EL;
using System;
using System.Data.Entity;
using System.Linq;
using System.Xml;

namespace DAL
{
    public class BancoDbContext : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'BancoDbContext' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'DAL.BancoDbContext' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'BancoDbContext'  en el archivo de configuración de la aplicación.
        public BancoDbContext()
            : base("name=BancoDbContext")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; } // CRUD
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}