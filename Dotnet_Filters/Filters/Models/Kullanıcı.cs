using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Filters.Models
{
    [Table("Kullanıcı")]
    public class Kullanıcı
    {
        public int id { get; set; }

        [Required,StringLength(20)]
        public string adı { get; set; }

        [Required,StringLength(20)]
        public string soyadı { get; set; }

        [Required,StringLength(20)]
        public string kullanıcıadı { get; set; }

        [Required,StringLength(10)]
        public string sifre { get; set; }





    }

}