using Postal;
using System.ComponentModel;

namespace CarLookUp.Web.ViewModels
{
    public class DetailsEmailVM : Email
    {
        public DetailsEmailVM(string viewName) : base(viewName)
        {
        }

        public string Maker { get; set; }
        public string Model { get; set; }
        public string Subject { get; set; }
        public string ToAddress { get; set; }
        public int Year { get; set; }
    }
}
