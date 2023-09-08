using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellness.Entities.Modal;
using Travellness.WebApi.DaraAccess.Database;
using Travellness.WebApi.DaraAccess.Store;

namespace Travellness.WebApi.Core.Implementation
{
    public class LoginManager : ILoginManager
    {
        private readonly IRegisterDbContext registerDbContext;

        private readonly IRegisterStore registerStore;   
        public LoginManager(IRegisterDbContext registerDbContext, IRegisterStore registerStore)
        {
            this.registerDbContext = registerDbContext;
            this.registerStore = registerStore;
        }

        public async Task<LoginResult> AuthenticateAsync(LoginModel loginModel)
        {
            try
            {
                
                var users = await registerStore.GetAllRegistersAsync();

                var user = users.FirstOrDefault(u => u.Email == loginModel.Email);

                if (user != null && user.Password == loginModel.Password)
                {
                    
                    return new LoginResult { Succeeded = true };
                }

                return new LoginResult { Succeeded = false, ErrorMessage = "Invalid email or password" };
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                
                throw; 
            }
        }
    }
}
