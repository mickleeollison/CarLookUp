using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLookUp.Core.ApplicationSettings
{
    public class TestApplicationSettings : BaseApplicationSettings
    {
        public static string DetailsEmail { get { return Get("DetailsEmail"); } }
        public static string SenderEmail { get { return Get("SenderEmail"); } }
    }
}
