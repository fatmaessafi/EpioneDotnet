using EpioneWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EpioneWeb
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base("name=EpioneDB")
        {

        }

        public DbSet <Users> Users { get; set; }
}
}