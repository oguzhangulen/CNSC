namespace SlugClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OgMg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uruns", "Kategori_Id", "dbo.Kategoris");
            DropForeignKey("dbo.Uruns", "Kullanici_Id", "dbo.Kullanicis");
            DropIndex("dbo.Uruns", new[] { "Kategori_Id" });
            DropIndex("dbo.Uruns", new[] { "Kullanici_Id" });
            AddColumn("dbo.Uruns", "KategoriId", c => c.Int());
            AddColumn("dbo.Uruns", "KullaniciId", c => c.Int());
            DropColumn("dbo.Uruns", "Kategori_Id");
            DropColumn("dbo.Uruns", "Kullanici_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Uruns", "Kullanici_Id", c => c.Int());
            AddColumn("dbo.Uruns", "Kategori_Id", c => c.Int());
            DropColumn("dbo.Uruns", "KullaniciId");
            DropColumn("dbo.Uruns", "KategoriId");
            CreateIndex("dbo.Uruns", "Kullanici_Id");
            CreateIndex("dbo.Uruns", "Kategori_Id");
            AddForeignKey("dbo.Uruns", "Kullanici_Id", "dbo.Kullanicis", "Id");
            AddForeignKey("dbo.Uruns", "Kategori_Id", "dbo.Kategoris", "Id");
        }
    }
}
