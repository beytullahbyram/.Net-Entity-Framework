using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Filters.Models
{
    [Table("Log tablosu")]
    public class Log
    {
        public int id { get; set; }
        [Required]
        public DateTime tarih { get; set; }
        [Required,StringLength(20)]
        public string kullanıcıadı { get; set; }

        [StringLength(50)]
        public string actionname { get; set; }

        [StringLength(50)]

        public string controllername { get; set; }
        [StringLength(250)]

        public string bilgi { get; set; }

    }
}