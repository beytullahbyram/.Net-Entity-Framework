namespace CodeFirst_sp.Migrations
{
    using CodeFirst_sp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst_sp.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //migration çalışmasını belirler
            ContextKey = "CodeFirst_sp.Models.DatabaseContext";
            AutomaticMigrationDataLossAllowed=true;//data kaybı oalcaksa izin ver
        }

        //context bizim databasemizi temsil eder
        //propjeyi her calıştırdıgımızda seed methodu çalışır bunun önüne geçmek için addorupdate methodu kullanırız
        protected override void Seed(CodeFirst_sp.Models.DatabaseContext context)
        {
            for (int i = 0; i < 35; i++)
            {
                //tekrar tekrar eklemesini engeller
                context.Books.AddOrUpdate(new Models.Book() 
                {
                    BookID=i+1,
                    Bookname=FakeData.NameData.GetCompanyName(),
                    Statement=FakeData.TextData.GetSentence(),
                    Releasedate=FakeData.DateTimeData.GetDatetime(),
                    Statement2=FakeData.TextData.GetSentence(),
                    Statement3=-1,
                    Statement4="test test"
                });
            }
            context.SaveChanges();

            for (int i = 1; i < 10; i++)
            {
               context.Authors.AddOrUpdate(new Models.Author()
                {
                   AuthorId=i,
                   Authorname=FakeData.NameData.GetFirstName(),
                   Dateofbirth=FakeData.DateTimeData.GetDatetime(),
                   Statement=FakeData.TextData.GetSentence(),
                });
            }
            context.SaveChanges();


        }
    }
}
