namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uf = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        Bairro = c.String(nullable: false),
                        Rua = c.String(nullable: false),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TelefoneId = c.Int(nullable: false),
                        Nome = c.String(),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecoes", t => t.EnderecoId, cascadeDelete: true)
                .ForeignKey("dbo.Telefones", t => t.TelefoneId, cascadeDelete: true)
                .Index(t => t.TelefoneId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Telefones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TelefoneId = c.Int(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                        Nome = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecoes", t => t.EnderecoId, cascadeDelete: true)
                .ForeignKey("dbo.Telefones", t => t.TelefoneId, cascadeDelete: true)
                .Index(t => t.TelefoneId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        RestauranteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotaDeProdutos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutosId = c.Int(),
                        NotasId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Preco = c.Single(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nota",
                c => new
                    {
                        ProdutoRefId = c.Int(nullable: false),
                        NotaRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProdutoRefId, t.NotaRefId })
                .ForeignKey("dbo.NotaDeProdutos", t => t.ProdutoRefId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.NotaRefId, cascadeDelete: true)
                .Index(t => t.ProdutoRefId)
                .Index(t => t.NotaRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nota", "NotaRefId", "dbo.Produtoes");
            DropForeignKey("dbo.Nota", "ProdutoRefId", "dbo.NotaDeProdutos");
            DropForeignKey("dbo.Restaurantes", "TelefoneId", "dbo.Telefones");
            DropForeignKey("dbo.Usuarios", "TelefoneId", "dbo.Telefones");
            DropForeignKey("dbo.Usuarios", "EnderecoId", "dbo.Enderecoes");
            DropForeignKey("dbo.Restaurantes", "EnderecoId", "dbo.Enderecoes");
            DropIndex("dbo.Nota", new[] { "NotaRefId" });
            DropIndex("dbo.Nota", new[] { "ProdutoRefId" });
            DropIndex("dbo.Usuarios", new[] { "EnderecoId" });
            DropIndex("dbo.Usuarios", new[] { "TelefoneId" });
            DropIndex("dbo.Restaurantes", new[] { "EnderecoId" });
            DropIndex("dbo.Restaurantes", new[] { "TelefoneId" });
            DropTable("dbo.Nota");
            DropTable("dbo.Produtoes");
            DropTable("dbo.NotaDeProdutos");
            DropTable("dbo.Notas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Telefones");
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Enderecoes");
        }
    }
}
