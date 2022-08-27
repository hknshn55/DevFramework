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
    //DİKKAT : Mapleme işlemi veri tabanına eder. Kesinlikle
    //normal(Fluent vs) validasyonlarla karıştırılmaması gerekir.
    //Arasındaki fark mapping işleminde veri tabanı şekillenmektedir.
    //Yani validasyonda 50 karakter aldınız ama mapingte 40 karakter
    //yapmanız demek veri kaybı veya hatalara yol açması demektir.

    //EntityTypeConfiguration entity framework üzerinde kullanılır.
    //CTOR ile kullanılır.
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);//Id primary keydir.
            builder.Property(x => x.Name).IsRequired();//ürün adı gereklidir.
        }
    }
}
