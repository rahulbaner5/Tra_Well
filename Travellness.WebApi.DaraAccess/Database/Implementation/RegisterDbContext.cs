using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellness.Entities.Modal;

namespace Travellness.WebApi.DaraAccess.Database.Implementation
{
    public class RegisterDbContext :DbContext, IRegisterDbContext
    {
        private readonly ILogger<RegisterDbContext> logger;

        public RegisterDbContext(DbContextOptions<RegisterDbContext> options, ILogger<RegisterDbContext> logger)
            : base(options)
        {
            this.logger = logger;
        }
        public DbSet<Register> Registers { get; set; }
        public async Task AddRegisterAsync(Register register)
        {
            try
            {
                
                var registrationEntity = new Register
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Email = register.Email,
                    Password = register.Password
                };

                this.Set<Register>().Add(registrationEntity);
                await this.SaveChangesAsync();

              

                logger.LogInformation($"Added registration for user with ID {registrationEntity.Id}");
            }
            catch (Exception ex)
            {
               
                logger.LogError($"Error adding registration: {ex.Message}");
                throw; 
            }
        }

        

        public async Task<Register> GetRegisterAsync(int id)
        {
            try
            {
               
               var registerEntity = await Registers.FindAsync(id);

                if (registerEntity != null)
                {
                    logger.LogInformation($"Retrieved registration for user with ID {registerEntity.Id}");
                    return registerEntity;
                }
                else
                {
                    logger.LogInformation($"No registration found for user with ID {id}");
                    return null; 
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error retrieving registration: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Register>> GetAllRegistersAsync()
        {
            try
            {
                var getAll = await Registers.ToListAsync();

                return getAll;
            }

            catch(Exception ex)
            {
                logger.LogError($"Error retrieving registration: {ex.Message}");
                throw;

            }
        }

    }
}

      
