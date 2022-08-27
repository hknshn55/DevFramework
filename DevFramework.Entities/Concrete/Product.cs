using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Entities.Concrete
{
    public class Product:IEntity
    {
        //Nhibernate üzerinde kulanılacaksa virtual eklenmesi gerekiyor.
        //Örn: public virtual int Id { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
