using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst_sp.Models
{
    [Table("Author")]
    public class Author
    {
        public int AuthorId{ get; set; }
        public string Authorname { get; set; }
        public string Statement { get; set; }
 
        public DateTime Dateofbirth { get; set; }





    }
}