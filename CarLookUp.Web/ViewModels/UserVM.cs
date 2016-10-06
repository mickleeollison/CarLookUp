using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarLookUp.Web.ViewModels
{
    public class UserVM
    {
        public int RoleId { get; set; }

        [Required]
        [MinLength(2)]
        public string UserName { get; set; }
    }
}
