using DevFramework.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
   public class CategoryMap:IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);//Id primary keydir.
            builder.Property(x => x.Name).IsRequired();//Kategori adı gereklidir.
        }
    }
}
