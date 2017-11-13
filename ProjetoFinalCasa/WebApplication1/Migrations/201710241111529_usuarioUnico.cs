namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuarioUnico : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Nome", c => c.String(maxLength: 50, unicode: false));
            CreateIndex("dbo.Usuarios", "Nome", unique: true, name: "IX_User_Login");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuarios", "IX_User_Login");
            AlterColumn("dbo.Usuarios", "Nome", c => c.String());
        }
    }
}
