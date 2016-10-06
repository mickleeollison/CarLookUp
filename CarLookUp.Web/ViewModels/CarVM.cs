using Postal;
using System.ComponentModel;

namespace CarLookUp.Web.ViewModels
{
    public class CarVM
    {
        public BodyTypeVM BodyType { get; set; }
        public int BodyTypeID { get; set; }
        public int ID { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
