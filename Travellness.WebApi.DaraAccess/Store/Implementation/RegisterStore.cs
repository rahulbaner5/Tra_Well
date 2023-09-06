using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellness.Entities.Modal;
using Travellness.WebApi.DaraAccess.Database;

namespace Travellness.WebApi.DaraAccess.Store.Implementation
{
    public class RegisterStore : IRegisterStore
    {
        private readonly IRegisterDbContext registerDbContext;
        
        private readonly ILogger<RegisterStore> logger;

        public RegisterStore(
            IRegisterDbContext registerDbContext,
            ILogger<RegisterStore> logger

            )
        {

            this.registerDbContext = registerDbContext;
            this.logger = logger;
        }

     
        public async Task AddRegisterAsync(Register register)
        {
            await this.registerDbContext.AddRegisterAsync(register);
        }
    }
}
