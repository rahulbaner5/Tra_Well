using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellness.Entities.Modal;

namespace Travellness.WebApi.Core
{
    public interface IRegisterManager
    {
        Task AddRegisterAsync(Register register);

    }
}
