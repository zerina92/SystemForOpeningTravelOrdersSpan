using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SystemForOpeningTravelOrdersSpan.Models
{
    public class TravelOrderDBContext : DbContext
    {
        public TravelOrderDBContext()
        {
            //Database.SetInitializer<EmployeeDBContext>(new CreateDatabaseIfNotExists<EmployeeDBContext>());

            Database.SetInitializer<TravelOrderDBContext>(new DropCreateDatabaseIfModelChanges<TravelOrderDBContext>());
        }
        public DbSet<TravelOrder> TravelOrders { get; set; }
    }
}