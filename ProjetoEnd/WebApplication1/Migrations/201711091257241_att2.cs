namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class att2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioRestaurantes", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRestaurantes", "Restaurante_RestauranteId", "dbo.Restaurantes");
            DropIndex("dbo.UsuarioRestaurantes", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.UsuarioRestaurantes", new[] { "Restaurante_RestauranteId" });
            CreateTable(
                "dbo.Favoritoes",
                c => new
                    {
                        FavoritoId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        RestauranteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FavoritoId);
            
            DropColumn("dbo.Restaurantes", "FavoritosUsuariosId");
            DropColumn("dbo.Usuarios", "RestaurantesFavoritosId");
            DropTable("dbo.UsuarioRestaurantes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsuarioRestaurantes",
                c => new
                    {
                        Usuario_UsuarioId = c.Int(nullable: false),
                        Restaurante_RestauranteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_UsuarioId, t.Restaurante_RestauranteId });
            
            AddColumn("dbo.Usuarios", "RestaurantesFavoritosId", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurantes", "FavoritosUsuariosId", c => c.Int(nullable: false));
            DropTable("dbo.Favoritoes");
            CreateIndex("dbo.UsuarioRestaurantes", "Restaurante_RestauranteId");
            CreateIndex("dbo.UsuarioRestaurantes", "Usuario_UsuarioId");
            AddForeignKey("dbo.UsuarioRestaurantes", "Restaurante_RestauranteId", "dbo.Restaurantes", "RestauranteId", cascadeDelete: true);
            AddForeignKey("dbo.UsuarioRestaurantes", "Usuario_UsuarioId", "dbo.Usuarios", "UsuarioId", cascadeDelete: true);
        }
    }
}
