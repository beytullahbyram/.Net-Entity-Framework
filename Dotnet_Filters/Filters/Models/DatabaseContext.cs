using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Filters.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Kullanıcı> kullanıcılar { get; set; }  
        public DbSet<Log> loglar{ get; set; }  




    }
}