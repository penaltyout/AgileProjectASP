using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingWebsite.Models.Entities
{
    public partial class TempDatabaseContext
    {
        public TempDatabaseContext(DbContextOptions<TempDatabaseContext> options)
            : base(options)
        {
        }

        public void AddCustomer(CustomersCreateVM customer)
        {
            var customerToAdd = new Customer
            {
                FirstName = customer.FirstName,
                Email = customer.Email,
                City = customer.City,
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                LastName = customer.LastName,
                Telephone = customer.Telephone,
                Mobilephone = customer.Mobilephone,
                ZipCode = customer.ZipCode,
                SocialSecurityNumber = customer.SocialSecurityNumber,
            };
            Customer.Add(customerToAdd);
            SaveChanges();
        }

        public void AddRoom(RoomsCreateVM room)
        {
            var roomToAdd = new Room
            {
                Name = room.Name,
                Description = room.Description
            };

            Room.Add(roomToAdd);
            SaveChanges();
        }

        public Customer[] GetCustomersForIndex()
        {
            return this.Customer.Where(o => o.FirstName == "korv").ToArray();
        }

        public Room[] GetRoomsForIndex()
        {
            return this.Room.Where(o => o.Name == "Nobel").ToArray();
            //return this.Room.Where(o => o.Name == "Nobel").ToArray();
        }

        public void AddUser(UserCreateVM user)
        {
            var userToAdd = new User
            {
                Customer_Id = Customer.SingleOrDefault(i => i.Email == user.Email).CustomerId,
                Password = user.Password,
                Username = user.Username
            };
            User.Add(userToAdd);
            SaveChanges();
        }
    }
}
