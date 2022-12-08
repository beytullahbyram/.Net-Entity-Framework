namespace CodeFirst_sp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Bookname = c.String(nullable: false, maxLength: 50),
                        Statement = c.String(),
                        Releasedate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateStoredProcedure(
                "dbo.InsertBook",
                p => new
                    {
                        Bookname = p.String(maxLength: 50),
                        Statement = p.String(),
                        Releasedate = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Book]([Bookname], [Statement], [Releasedate])
                      VALUES (@Bookname, @Statement, @Releasedate)
                      
                      DECLARE @BookID int
                      SELECT @BookID = [BookID]
                      FROM [dbo].[Book]
                      WHERE @@ROWCOUNT > 0 AND [BookID] = scope_identity()
                      
                      SELECT t0.[BookID]
                      FROM [dbo].[Book] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[BookID] = @BookID"
            );
            
            CreateStoredProcedure(
                "dbo.UpdateBook",
                p => new
                    {
                        BookID = p.Int(),
                        Bookname = p.String(maxLength: 50),
                        Statement = p.String(),
                        Releasedate = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Book]
                      SET [Bookname] = @Bookname, [Statement] = @Statement, [Releasedate] = @Releasedate
                      WHERE ([BookID] = @BookID)"
            );
            
            CreateStoredProcedure(
                "dbo.DeleteBook",
                p => new
                    {
                        BookID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Book]
                      WHERE ([BookID] = @BookID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteBook");
            DropStoredProcedure("dbo.UpdateBook");
            DropStoredProcedure("dbo.InsertBook");
            DropTable("dbo.Book");
        }
    }
}
