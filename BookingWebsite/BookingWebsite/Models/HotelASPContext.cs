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

        #region User functions
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

        public UsersDetailsVM FindUserById(string id)
        {
            var user = User.Single(i => i.AspNetUserId == id);


            var userForDetails = new UsersDetailsVM
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

        public int GetUserIdFromAspNetUserId(string aspNetUserId)
        {
            return User.Where(i => i.AspNetUserId == aspNetUserId).Select(i => i.Id).Single();
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
        #endregion

        #region Bookings functions
        public BookingsIndexVM[] GetBookingsIndexVMForIndex()
        {
            return Booking.Select(i => new BookingsIndexVM
            {
                Id = i.Id,
                RoomId = i.RoomId,
                UserId = i.UserId,
                StartDate = i.StartDate,
                EndDate = i.EndDate,
                Statuscode = i.Statuscode,
                CustomerName = User.Where(u => u.Id == i.UserId).Select(u => u.FirstName + " " + u.LastName).Single(),
                RoomName = Room.Where(r => r.Id == i.RoomId).Select(r => r.Name).Single()
            }).ToArray();
        }

        //public BookingsSuccessfullVM GetBookingsSuccessfullVMForBookingsSuccessfull (int id)
        //{
        //    Booking booking = Booking.Single(b => b.Id == id);
        //    return new BookingsSuccessfullVM
        //    {
        //        Id = booking.Id,
        //        RoomId = booking.RoomId,
        //        UserId = booking.UserId,
        //        CustomerName = User.Where(u => u.Id == booking.UserId).Select(u => u.FirstName + " " + u.LastName).Single(),
        //        RoomName = Room.Where(r => r.Id == booking.RoomId).Select(r => r.Name).Single(),
        //        StartDate=booking.StartDate,
        //        EndDate = booking.EndDate
        //    };
        //}

        public void CreateBooking(BookingsCreateVM booking)
        {
            var bookingToAdd = new Booking
            {
                RoomId = booking.RoomId,
                UserId = booking.UserId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                //Statuscode = booking.Statuscode
            };

            Booking.Add(bookingToAdd);
            SaveChanges();
        }

        //public BookingsEditVM GetBookingForEdit(int id)
        //{
        //    Booking bookingToConvert = Booking.Single(i => i.Id == id);
        //    return new BookingsEditVM
        //    {
        //        UserId = bookingToConvert.UserId,
        //        RoomId = bookingToConvert.RoomId,
        //        StartDate = bookingToConvert.StartDate,
        //        Statuscode = bookingToConvert.Statuscode
        //    };
        //}

        public BookingsDetailsVM[] GetBookingsDetailsVMForUserBookingsDetails(int id)
        {
            return Booking.Where(b => b.UserId == id).Select(b => new BookingsDetailsVM
            {
                Id = b.Id,
                RoomId = b.RoomId,
                UserId = b.UserId,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                CustomerName = User.Where(u => u.Id == b.UserId).Select(u => u.FirstName + " " + u.LastName).Single(),
                RoomNumber = Room.Where(r => r.Id == b.RoomId).Select(r => r.Number).Single()
                //Statuscode = booking.Statuscode
            }).ToArray();
        }
#endregion

        #region Rooms functions
        public RoomsIndexVM[] GetRoomsIndexVMsForIndex()
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

        public RoomsDetailsVM GetRoomsDetailsVMForDetails(int id, IHostingEnvironment env)
        {
            var room = this.Room.Single(i => i.Id == id);
            return new RoomsDetailsVM(env)
            {
                Id = room.Id,
                Name = room.Name,
                Number = room.Number,
                Description = room.Description,
                Price = room.Price,
                Size = room.Size
                
            };
        }

        public RoomsEditVM GetRoomForEditById(int id)
        {
            Room roomToSend = Room.Single(i => i.Id == id);
            return new RoomsEditVM
            {
                Id = roomToSend.Id,
                Name = roomToSend.Name,
                Number = roomToSend.Number,
                Description = roomToSend.Description,
                Price = roomToSend.Price,
                Size = roomToSend.Size
            };
        }

        public void CreateRoom(RoomsCreateVM room)
        {
            var roomToAdd = new Room
            {
                Name = room.Name,
                Number = room.Number,
                Description = room.Description,
                Price = room.Price,
                Size = room.Size
            };

            Room.Add(roomToAdd);
            SaveChanges();
        }

        public void UpdateRoom(RoomsEditVM room)
        {
            Room roomToUpdate = this.Room.Single(i => i.Id == room.Id);

            if(room.Name != null) roomToUpdate.Name = room.Name;
            roomToUpdate.Number = room.Number;
            if (room.Description != null) roomToUpdate.Description = room.Description;
            if (room.Price != null) roomToUpdate.Price = room.Price;
            if (room.Size != null) roomToUpdate.Size = room.Size;

            SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var roomToDelete = this.Room.Single(i => i.Id == id);

            Room.Remove(roomToDelete);
            SaveChanges();
        }
        #endregion

        #region Customer functions
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
        #endregion
    }
}
