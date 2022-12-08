using CodeFirst_sp.Models.ProcedureModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst_sp.Models.Combine_Model
{
    public class CombineModel
    {
        public List<BookInfoView> BookView { get; set; }
        public List<BookPublishing> BookPublishing { get; set; }
        public List<Author> Authors { get; set; }
    }
}