using CarLookUp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLookUp.Services.Services.Interfaces
{
    public interface ILoginService
    {
        void LoginUser(UserDTO user, ValidationMessageList messages);

        void Logoff();
    }
}
