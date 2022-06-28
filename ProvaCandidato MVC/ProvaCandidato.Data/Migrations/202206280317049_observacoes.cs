namespace ProvaCandidato.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class observacoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClienteObservacao",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        codigo_cliente = c.Int(nullable: false),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.Cliente", t => t.codigo_cliente, cascadeDelete: true)
                .Index(t => t.codigo_cliente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteObservacao", "codigo_cliente", "dbo.Cliente");
            DropIndex("dbo.ClienteObservacao", new[] { "codigo_cliente" });
            DropTable("dbo.ClienteObservacao");
        }
    }
}
