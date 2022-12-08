namespace CodeFirst_sp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookTableAddStatemen4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Statement4", c => c.String
            (nullable:false,defaultValue:"statement4",defaultValueSql:"statemen4 test"));
            AlterStoredProcedure(
                "dbo.InsertBook",
                p => new
                    {
                        Bookname = p.String(maxLength: 50),
                        Statement = p.String(),
                        Statement2 = p.String(maxLength: 200),
                        Statement3 = p.Int(),
                        Statement4 = p.String(),
                        Releasedate = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Book]([Bookname], [Statement], [Statement2], [Statement3], [Statement4], [Releasedate])
                      VALUES (@Bookname, @Statement, @Statement2, @Statement3, @Statement4, @Releasedate)
                      
                      DECLARE @BookID int
                      SELECT @BookID = [BookID]
                      FROM [dbo].[Book]
                      WHERE @@ROWCOUNT > 0 AND [BookID] = scope_identity()
                      
                      SELECT t0.[BookID]
                      FROM [dbo].[Book] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[BookID] = @BookID"
            );
            
            AlterStoredProcedure(
                "dbo.UpdateBook",
                p => new
                    {
                        BookID = p.Int(),
                        Bookname = p.String(maxLength: 50),
                        Statement = p.String(),
                        Statement2 = p.String(maxLength: 200),
                        Statement3 = p.Int(),
                        Statement4 = p.String(),
                        Releasedate = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Book]
                      SET [Bookname] = @Bookname, [Statement] = @Statement, [Statement2] = @Statement2, [Statement3] = @Statement3, [Statement4] = @Statement4, [Releasedate] = @Releasedate
                      WHERE ([BookID] = @BookID)"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Statement4");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
