using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLookUp.Data.Entities
{
    public class Car
    {
        public virtual BodyType BodyType { get; set; }
        public int BodyTypeID { get; set; }
        public int ID { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
