using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellness.Entities.Modal;

namespace Travellness.WebApi.Core
{
    public interface ILoginManager
    {
        Task<LoginResult> AuthenticateAsync(LoginModel loginModel);
    }

}
