using CodeFirst_sp.Models;
using CodeFirst_sp.Models.Combine_Model;
using CodeFirst_sp.Models.ProcedureModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_sp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DatabaseContext db=new DatabaseContext();
            db.Books.ToList();
            //db.SpTestExec(); //sp çalıştırdık

            List<BookPublishing> hangiyıldakackitapvar= db.SpTextExecBookGet(2005,2025);//procedur çalıştı ve bize bookpublishing türünden bize liste geri döndürdü
            List<BookInfoView> kitapbilgileri=db.SpTextExecBookInfoView();
            List<Author> authors = db.Authors.ToList();

            CombineModel combineModel=new CombineModel()
            {
                BookPublishing=hangiyıldakackitapvar,
                BookView=kitapbilgileri,
                Authors = authors
            };

            #region Database test insert stroprocedure
            //db.Books.Add(new Book()
            //{
            //    Bookname="tutunamayanlar",
            //    Statement="deneme",
            //    Releasedate=DateTime.Now
            //});
            //db.SaveChanges();
            #endregion
            return View(combineModel);
        }
    }
}