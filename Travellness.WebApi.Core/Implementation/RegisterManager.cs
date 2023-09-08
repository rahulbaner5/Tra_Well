using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellness.Entities.Modal;
using Travellness.WebApi.DaraAccess.Store;

namespace Travellness.WebApi.Core.Implementation
{
    public class RegisterManager : IRegisterManager
    {

        private readonly IRegisterStore registerStore;
        
        private readonly ILogger<RegisterManager> logger;


        public RegisterManager(
            
            
            IRegisterStore registerStore, ILogger<RegisterManager> logger)
        {
            this.registerStore = registerStore;
            this.logger = logger;
        }

        public async Task AddRegisterAsync(Register register)
        {
            await this.registerStore.AddRegisterAsync(register);

        }

      
        Task<Register> IRegisterManager.GetRegisterAsync(int id)
        {
            try
            {
                return  this.registerStore.GetRegisterAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error getting registration: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Register>> GetAllRegistersAsync()
        {
           return await this.registerStore.GetAllRegistersAsync();
        }
    }
}
