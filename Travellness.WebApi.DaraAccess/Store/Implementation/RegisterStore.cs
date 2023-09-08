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

        public async Task<IEnumerable<Register>> GetAllRegistersAsync()
        {
            return await this.registerDbContext.GetAllRegistersAsync();

        }

        Task <Register> IRegisterStore.GetRegisterAsync(int id)
        {
            try
            {
                return  this.registerDbContext.GetRegisterAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error getting registration: {ex.Message}");
                throw;
            }
        }
    }
}
