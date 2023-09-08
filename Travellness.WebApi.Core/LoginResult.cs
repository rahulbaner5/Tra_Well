using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travellness.WebApi.Core
{
    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
