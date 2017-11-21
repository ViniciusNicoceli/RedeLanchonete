namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class att3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurantes", "EnderecoId", "dbo.Enderecoes");
            DropForeignKey("dbo.Produtoes", "RestauranteId", "dbo.Restaurantes");
            DropForeignKey("dbo.Restaurantes", "TelefoneId", "dbo.Telefones");
            DropForeignKey("dbo.Usuarios", "EnderecoId", "dbo.Enderecoes");
            DropForeignKey("dbo.Usuarios", "TelefoneId", "dbo.Telefones");
            CreateIndex("dbo.Favoritoes", "UsuarioId");
            CreateIndex("dbo.Favoritoes", "RestauranteId");
            AddForeignKey("dbo.Favoritoes", "RestauranteId", "dbo.Restaurantes", "RestauranteId");
            AddForeignKey("dbo.Favoritoes", "UsuarioId", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Restaurantes", "EnderecoId", "dbo.Enderecoes", "EnderecoId");
            AddForeignKey("dbo.Produtoes", "RestauranteId", "dbo.Restaurantes", "RestauranteId");
            AddForeignKey("dbo.Restaurantes", "TelefoneId", "dbo.Telefones", "TelefoneId");
            AddForeignKey("dbo.Usuarios", "EnderecoId", "dbo.Enderecoes", "EnderecoId");
            AddForeignKey("dbo.Usuarios", "TelefoneId", "dbo.Telefones", "TelefoneId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "TelefoneId", "dbo.Telefones");
            DropForeignKey("dbo.Usuarios", "EnderecoId", "dbo.Enderecoes");
            DropForeignKey("dbo.Restaurantes", "TelefoneId", "dbo.Telefones");
            DropForeignKey("dbo.Produtoes", "RestauranteId", "dbo.Restaurantes");
            DropForeignKey("dbo.Restaurantes", "EnderecoId", "dbo.Enderecoes");
            DropForeignKey("dbo.Favoritoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Favoritoes", "RestauranteId", "dbo.Restaurantes");
            DropIndex("dbo.Favoritoes", new[] { "RestauranteId" });
            DropIndex("dbo.Favoritoes", new[] { "UsuarioId" });
            AddForeignKey("dbo.Usuarios", "TelefoneId", "dbo.Telefones", "TelefoneId", cascadeDelete: true);
            AddForeignKey("dbo.Usuarios", "EnderecoId", "dbo.Enderecoes", "EnderecoId", cascadeDelete: true);
            AddForeignKey("dbo.Restaurantes", "TelefoneId", "dbo.Telefones", "TelefoneId", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "RestauranteId", "dbo.Restaurantes", "RestauranteId", cascadeDelete: true);
            AddForeignKey("dbo.Restaurantes", "EnderecoId", "dbo.Enderecoes", "EnderecoId", cascadeDelete: true);
        }
    }
}
