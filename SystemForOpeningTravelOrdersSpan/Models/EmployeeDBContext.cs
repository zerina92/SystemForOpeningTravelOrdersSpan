using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SystemForOpeningTravelOrdersSpan.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
            //Database.SetInitializer<EmployeeDBContext>(new CreateDatabaseIfNotExists<EmployeeDBContext>());

            Database.SetInitializer<EmployeeDBContext>(new DropCreateDatabaseIfModelChanges<EmployeeDBContext>());
        }
        public DbSet<Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<SystemForOpeningTravelOrdersSpan.Models.TravelOrder> TravelOrders { get; set; }
    }
}