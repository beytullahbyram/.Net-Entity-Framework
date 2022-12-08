using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst_sp.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required,StringLength(50)]
        public string Bookname { get; set; }
        public string Statement { get; set; }
        
        [Required,StringLength(200)]
        public string Statement2 { get; set; }

        public int Statement3 { get; set; }
        //migration için bu kolonu ekledik
        public string Statement4 { get; set; }

        public DateTime Releasedate { get; set; }

    }
}