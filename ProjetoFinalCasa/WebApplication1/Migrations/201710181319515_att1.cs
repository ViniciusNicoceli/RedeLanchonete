namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class att1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestauranteProdutoes", "Restaurante_RestauranteId", "dbo.Restaurantes");
            DropForeignKey("dbo.RestauranteProdutoes", "Produto_ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "NotaDeProdutos_NotaDeProdutosId", "dbo.NotaDeProdutos");
            DropIndex("dbo.Produtoes", new[] { "NotaDeProdutos_NotaDeProdutosId" });
            DropIndex("dbo.RestauranteProdutoes", new[] { "Restaurante_RestauranteId" });
            DropIndex("dbo.RestauranteProdutoes", new[] { "Produto_ProdutoId" });
            AddColumn("dbo.Produtoes", "RestauranteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "RestauranteId");
            AddForeignKey("dbo.Produtoes", "RestauranteId", "dbo.Restaurantes", "RestauranteId", cascadeDelete: true);
            DropColumn("dbo.Produtoes", "NotaDeProdutos_NotaDeProdutosId");
            DropTable("dbo.Notas");
            DropTable("dbo.NotaDeProdutos");
            DropTable("dbo.RestauranteProdutoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RestauranteProdutoes",
                c => new
                    {
                        Restaurante_RestauranteId = c.Int(nullable: false),
                        Produto_ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurante_RestauranteId, t.Produto_ProdutoId });
            
            CreateTable(
                "dbo.NotaDeProdutos",
                c => new
                    {
                        NotaDeProdutosId = c.Int(nullable: false, identity: true),
                        ProdutosId = c.Int(nullable: false),
                        NotasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotaDeProdutosId);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        NotaId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        RestauranteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotaId);
            
            AddColumn("dbo.Produtoes", "NotaDeProdutos_NotaDeProdutosId", c => c.Int());
            DropForeignKey("dbo.Produtoes", "RestauranteId", "dbo.Restaurantes");
            DropIndex("dbo.Produtoes", new[] { "RestauranteId" });
            DropColumn("dbo.Produtoes", "RestauranteId");
            CreateIndex("dbo.RestauranteProdutoes", "Produto_ProdutoId");
            CreateIndex("dbo.RestauranteProdutoes", "Restaurante_RestauranteId");
            CreateIndex("dbo.Produtoes", "NotaDeProdutos_NotaDeProdutosId");
            AddForeignKey("dbo.Produtoes", "NotaDeProdutos_NotaDeProdutosId", "dbo.NotaDeProdutos", "NotaDeProdutosId");
            AddForeignKey("dbo.RestauranteProdutoes", "Produto_ProdutoId", "dbo.Produtoes", "ProdutoId", cascadeDelete: true);
            AddForeignKey("dbo.RestauranteProdutoes", "Restaurante_RestauranteId", "dbo.Restaurantes", "RestauranteId", cascadeDelete: true);
        }
    }
}
