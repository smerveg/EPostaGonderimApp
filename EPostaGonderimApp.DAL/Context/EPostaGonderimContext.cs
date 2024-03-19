using EPostaGonderimApp.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.DAL.Context
{
    public class EPostaGonderimContext:DbContext
    {
        public EPostaGonderimContext()
        {

        }
        public EPostaGonderimContext(DbContextOptions<EPostaGonderimContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }


        public DbSet<EPostaAdres> EPostaAdresleri { get; set; }
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<EPosta> EPostalar { get; set; }
        
    }
}
