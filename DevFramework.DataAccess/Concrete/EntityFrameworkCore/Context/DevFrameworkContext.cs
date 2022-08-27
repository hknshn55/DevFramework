using DevFramework.DataAccess.Concrete.EntityFrameworkCore.Mappings;
using DevFramework.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class DevFrameworkContext:DbContext
    {
        //public DevFrameworkContext()
        //{
        //    Database.SetInitializer<DevFrameworkContext>(null);
        //}
        //public DevFrameworkContext(DbContextOptions<DevFrameworkContext> options) : base(options)
        //{
        //    bağlantıyı uı da belirt unutma!
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Uyguladığımız mapping işlemini eklememiz gerekir.
            //Eklemezsek başlattığında mapingimizi görmez.
            modelBuilder.ApplyConfiguration(new ProductMap());

            //EntityFramework => modelBuilder.Configuration.Add(new ProductMap);

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
