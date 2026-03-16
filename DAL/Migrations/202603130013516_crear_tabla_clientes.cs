namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crear_tabla_clientes : DbMigration
    {
        public override void Up()
        {  
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Documento = c.String(),
                        Email = c.String(),
                        Telefono = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
