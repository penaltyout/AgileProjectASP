using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingWebsite.Models.Entities
{
    public partial class HotelASPContext
    {
        public HotelASPContext(DbContextOptions<HotelASPContext> options)
            : base(options)
        {
        }
        public void AddUser(UsersRegisterVM model)
        {
            var userToAdd = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                AspNetUserId = model.AspNetUserId,
                City = model.City,
                ZipCode = model.ZipCode,
            };
            User.Add(userToAdd);

            SaveChanges();
        }

        public User[] GetUsersForIndex()
        {
            return User.ToArray();
        }

        public UsersDetailVM FindUserById(string id)
        {
            var user = User.Single(i => i.AspNetUserId == id);
            
            
            var userForDetails = new UsersDetailVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                ZipCode = user.ZipCode
           };
            return userForDetails;
        }

        public void FindUserForEditByID(string id, UsersEditVM model)
        {
            var user = User.Single(i => i.AspNetUserId == id);
            if (model.FirstName != null) user.FirstName = model.FirstName;
            if (model.LastName != null) user.LastName = model.LastName;
            if (model.AddressLine1 != null) user.AddressLine1 = model.AddressLine1;
            if (model.AddressLine2 != null) user.AddressLine2 = model.AddressLine2;
            if (model.City != null) user.City = model.City;
            if (model.ZipCode != null) user.ZipCode = model.ZipCode;

            SaveChanges();
        }

        public void AddRoom(RoomsCreateVM room)
        {
            var roomToAdd = new Room
            { 
                Id = room.Id,
                Name = room.Name,
                Number = room.Number,
                Description = room.Description,
                Price = room.Price,
                Size = room.Size
            };

            Room.Add(roomToAdd);
            SaveChanges();
        }

        public void EditRoom(RoomsEditVM room)
        {
            var roomToEdit = this.Room.Single(i => i.Id == room.Id);

            if (room.Name != null) roomToEdit.Name = room.Name;
            if (room.Number != null) roomToEdit.Number = room.Number;
            if (room.Description != null) roomToEdit.Description = room.Description;
            if (room.Price != null) roomToEdit.Price = room.Price;
            if (room.Size != null) roomToEdit.Size = room.Size;

            SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var roomToDelete = this.Room.Single(i => i.Id == id);

            Room.Remove(roomToDelete);
            SaveChanges();
        }

        public Room[] GetRoomsForIndex()
        {
            return this.Room.ToArray();
        }

        public Room GetRoomForDetail(int id)
        {
            return this.Room.Where(o => o.Id == id).Single();
        }

        public RoomsIndexVM[] GetRoomsIndexVMForIndex()
        {
            return this.Room.Select(i => new RoomsIndexVM
            {
                Id = i.Id,
                Name = i.Name,
                Number = i.Number,
                Description = i.Description,
                Price = i.Price,
                Size = i.Size

            }).ToArray();
        }

        public RoomsDetailVM GetRoomsDetailVMForDetail(int id, IHostingEnvironment env)
        {
            var room = this.Room.Single(i => i.Id == id);
            return new RoomsDetailVM (env)
            {
                Id = room.Id,
                Name = room.Name,
                Number = room.Number,
                Description = room.Description,
                Price = room.Price,
                Size = room.Size
            };
        }

        //public void AddCustomer(CustomersCreateVM customer)
        //{


        //    //var customerToAdd = new Customer
        //    //{

        //    //    FirstName = customer.FirstName,
        //    //    Email = customer.Email,
        //    //    City = customer.City,
        //    //    AddressLine1 = customer.AddressLine1,
        //    //    AddressLine2 = customer.AddressLine2,
        //    //    LastName = customer.LastName,
        //    //    Telephone = customer.Telephone,
        //    //    Mobilephone = customer.Mobilephone,
        //    //    ZipCode = customer.ZipCode,
        //    //    SocialSecurityNumber = customer.SocialSecurityNumber,



        //    //};
        //    //Customer.Add(customerToAdd);

        //    SaveChanges();

        //}

        //public Customer[] GetCustomersForIndex()
        //{
        //    return Customer.ToArray();
        //}

        //public void AddUser(UserCreateVM usr)
        //{
        //    User userToAdd = new User
        //    {
        //        //Customer_Id = Customer.SingleOrDefault(i => i.Email == usr.Email).CustomerId,
        //        Customer_Id = Customer.Single(i => i.Email == usr.Email).CustomerId,


        //    };
        //    User.Add(userToAdd);
        //    SaveChanges();

        //}

        //public Customer FindCustomerById(int id)
        //{
        //    return Customer.SingleOrDefault(i => i.CustomerId == id);
        //}

        //internal void EditCustomer(Customer customer)
        //{
        //    var customerToFind = Customer.Find(customer.CustomerId);
        //    customerToFind.FirstName = customer.FirstName;
        //    customerToFind.LastName = customer.LastName;
        //    customerToFind.Telephone = customer.Telephone;
        //    SaveChanges();
        //}
    }
}
