using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kullanici
    {
        public Guid ID { get; set; }
        public string  Kullaniciadi { get; set; }
        public string  Sifre { get; set; }
    }
}
