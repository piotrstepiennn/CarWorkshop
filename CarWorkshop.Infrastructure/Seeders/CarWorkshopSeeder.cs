using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync()) 
            {
                if(!_dbContext.CarWorkshops.Any())
                {
                    var nissanAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Nissan ASO",
                        Description = "Authorized Nissan Service",
                        ContactDetails = new()
                        {
                            City = "Warsaw",
                            Street = "Pulawska",
                            PostalCode = "11-111",
                            PhoneNumber = "+48123123123"
                        }
                    };
                    nissanAso.EncodeName();

                    _dbContext.CarWorkshops.Add(nissanAso);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
