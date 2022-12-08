using CodeFirst_sp.Migrations;
using CodeFirst_sp.Models.ProcedureModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst_sp.Models
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; } //tablo görevi görür
        public DatabaseContext()
        {
            //veritabanıoluşturucu classını tetiklemiş olduk
            //Database.SetInitializer(new VeriTabanıOluşturucu());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext,Configuration>());
        }

        //veritabanı create edilirken
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //storeprocedure oluşturma işlemi
            modelBuilder.Entity<Book>().MapToStoredProcedures(config =>
            {
                //varsayılan olarak oluşturulan storeprocedur isimlerini değiştirdik
                config.Insert(i => i.HasName("InsertBook"));
                config.Update(u =>
                {
                    u.HasName("UpdateBook"); 
                    //u.Parameter(p=>p.BookID,"BookID");BURADA parametre ismini değiştirebiliriz
                    });
                config.Delete(d => d.HasName("DeleteBook"));
            });
        }

        #region Sql storeprocedure methodlarımız
        //procedure için bir method 
        //public void SpTestExec()
        //{
        //    Database.ExecuteSqlCommand("exec InsertData");

        //}

        //bu method bize hangi yıllarda kaç kitap oldugunu bize gösteren bir method 
        public  List<BookPublishing>  SpTextExecBookGet(int baslangic,int bitis)
        {
            //procedur bize bir tablo geri dönüyor biz bu tabloyu bookpublishing classına benzettik ve bu classı kullanarak geri dönen değerleri artık kullanabiliriz
           return  Database.SqlQuery<BookPublishing>("exec BookGet @p0,@p1",baslangic,bitis).ToList();
        }

        public List<BookInfoView> SpTextExecBookInfoView()
        {
            return Database.SqlQuery<BookInfoView>("select * from BookInfo").ToList();
        }


        //public List<AuthorInfoView> SpTextExecAuthorInfoView()
        //{

        //}
        #endregion

    }

    //veritabanı yoksa databasecontext veritabanı oluştur ve seed methodu çalışacak
    //Bu class tetiklendiğinde eğer veritabanı yoksa oluştur ve seed methodunu çalıştır
    public class VeriTabanıOluşturucu : CreateDatabaseIfNotExists<DatabaseContext>
    {
        //veritabanı oluştuktan sonra seed methodu çalışacak
        protected override void Seed(DatabaseContext context)
        {
            //sql komutlarımı yazdık
            context.Database.ExecuteSqlCommand("create procedure InsertData as begin insert into Book values('tutunamayanlar','oguz atay','2010-01-01') insert into Book values('suc ve ceza','dostoyevski','2010-02-02') end");
            context.Database.ExecuteSqlCommand("create proc BookGet @p0 int, @p1 int as begin select Releasedate,COUNT(Releasedate) as piece from Book Where YEAR(Releasedate) between @p0 and @p1 group by Releasedate end");
            context.Database.ExecuteSqlCommand(" create view BookInfo as select Bookname,Statement from Book");
        }
    }


}