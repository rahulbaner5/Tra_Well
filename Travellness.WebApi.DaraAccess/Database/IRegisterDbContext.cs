using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellness.Entities.Modal;

namespace Travellness.WebApi.DaraAccess.Database
{
    public  interface IRegisterDbContext
    {
        Task AddRegisterAsync(Register register);
        Task<Register> GetRegisterAsync(int id);
        Task<IEnumerable<Register>> GetAllRegistersAsync();


    }
}
