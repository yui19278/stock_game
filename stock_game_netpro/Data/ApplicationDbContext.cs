using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

using System.Data.Entity;

namespace stock_game_netpro.Data
{
    //
    public class ApplicationDbContext : DbContext //DbContextを継承する
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Currency> Currencies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}