namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        RestauranteId = c.Int(nullable: false),
                        Uf = c.String(),
                        Cidade = c.String(),
                        Bairro = c.String(),
                        Rua = c.String(),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        NotaId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        RestauranteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotaId);
            
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
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Preco = c.Single(nullable: false),
                        Descricao = c.String(),
                        NotaDeProdutos_NotaDeProdutosId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.NotaDeProdutos", t => t.NotaDeProdutos_NotaDeProdutosId)
                .Index(t => t.NotaDeProdutos_NotaDeProdutosId);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        RestauranteId = c.Int(nullable: false, identity: true),
                        TelefoneId = c.Int(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.RestauranteId)
                .ForeignKey("dbo.Enderecoes", t => t.EnderecoId, cascadeDelete: true)
                .ForeignKey("dbo.Telefones", t => t.TelefoneId, cascadeDelete: true)
                .Index(t => t.TelefoneId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Telefones",
                c => new
                    {
                        TelefoneId = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.TelefoneId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        TelefoneId = c.Int(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                        Nome = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Enderecoes", t => t.EnderecoId, cascadeDelete: true)
                .ForeignKey("dbo.Telefones", t => t.TelefoneId, cascadeDelete: true)
                .Index(t => t.TelefoneId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.RestauranteProdutoes",
                c => new
                    {
                        Restaurante_RestauranteId = c.Int(nullable: false),
                        Produto_ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurante_RestauranteId, t.Produto_ProdutoId })
                .ForeignKey("dbo.Restaurantes", t => t.Restaurante_RestauranteId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.Produto_ProdutoId, cascadeDelete: true)
                .Index(t => t.Restaurante_RestauranteId)
                .Index(t => t.Produto_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "TelefoneId", "dbo.Telefones");
            DropForeignKey("dbo.Usuarios", "EnderecoId", "dbo.Enderecoes");
            DropForeignKey("dbo.Produtoes", "NotaDeProdutos_NotaDeProdutosId", "dbo.NotaDeProdutos");
            DropForeignKey("dbo.Restaurantes", "TelefoneId", "dbo.Telefones");
            DropForeignKey("dbo.RestauranteProdutoes", "Produto_ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.RestauranteProdutoes", "Restaurante_RestauranteId", "dbo.Restaurantes");
            DropForeignKey("dbo.Restaurantes", "EnderecoId", "dbo.Enderecoes");
            DropIndex("dbo.RestauranteProdutoes", new[] { "Produto_ProdutoId" });
            DropIndex("dbo.RestauranteProdutoes", new[] { "Restaurante_RestauranteId" });
            DropIndex("dbo.Usuarios", new[] { "EnderecoId" });
            DropIndex("dbo.Usuarios", new[] { "TelefoneId" });
            DropIndex("dbo.Restaurantes", new[] { "EnderecoId" });
            DropIndex("dbo.Restaurantes", new[] { "TelefoneId" });
            DropIndex("dbo.Produtoes", new[] { "NotaDeProdutos_NotaDeProdutosId" });
            DropTable("dbo.RestauranteProdutoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Telefones");
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Produtoes");
            DropTable("dbo.NotaDeProdutos");
            DropTable("dbo.Notas");
            DropTable("dbo.Enderecoes");
        }
    }
}
