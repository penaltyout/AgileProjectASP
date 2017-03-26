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

        public BookingsDetailVM[] GetBookingsDetailVMForUserBookingsDetail(int id)
        {
            return Booking.Where(b => b.UserId == id).Select(b => new BookingsDetailVM
            {
                Id = b.Id,
                RoomId = b.RoomId,
                UserId = b.UserId,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                CustomerName = User.Where(u => u.Id == b.UserId).Select(u => u.FirstName + " " + u.LastName).Single(),
                RoomNumber = Room.Where(r => r.Id == b.RoomId).Select(r => r.Number).Single()
            }).ToArray();
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
            return new RoomsDetailVM(env)
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

            if (room.Name != null) roomToUpdate.Name = room.Name;
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
    }        
}
