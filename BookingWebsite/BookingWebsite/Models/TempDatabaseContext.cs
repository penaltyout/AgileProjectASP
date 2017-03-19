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
                Description = room.Description,
                Price = room.Price,
                Size = room.Size
            };

            Room.Add(roomToAdd);
            SaveChanges();
        }

        public Customer[] GetCustomersForIndex()
        {
            return this.Customer.ToArray();
        }

        public Room[] GetRoomsForIndex()
        {
            return this.Room.ToArray();
            //return this.Room.Where(o => o.Name == "Nobel").ToArray();
        }

        public Room GetRoomForDetail(int id)
        {
            return this.Room.Where(o => o.RoomId == id).Single();
        }

        public void AddUser(UserCreateVM user)
        {
            var userToAdd = new User
            {
                Customer_Id = Customer.Single(i => i.Email == user.Email).CustomerId,
                Password = user.Password,
                Username = user.Username
            };
            User.Add(userToAdd);
            SaveChanges();
        }

        public void AddBooking(BookingsCreateVM booking)
        {
            var bookingToAdd = new Booking
            {
                //BookingId = booking.BookingId,
                Customer_Id = Customer.Single(i => i.CustomerId == booking.CustomerId).CustomerId,
                Room_Id = Room.Single(i => i.RoomId == booking.RoomId).RoomId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Statuscode = booking.Statuscode
            };

            Booking.Add(bookingToAdd);
            SaveChanges();
        }

        public Booking[] GetBookingsForIndex()
        {
            return this.Booking.ToArray();
        }

        public Booking GetBookingForDetail(int id)
        {
            return this.Booking.Where(o => o.BookingId == id).Single();
        }

        public Customer GetCustomerForDetail(int id)
        {
            return this.Customer.Where(o => o.CustomerId == id).Single();
            //return Customer.SingleOrDefault(i => i.CustomerId == id);
        }

        internal void EditCustomer(Customer customer)
        {
            var customerToEdit = Customer.Find(customer.CustomerId);
            customerToEdit.FirstName = customer.FirstName;
            customerToEdit.LastName = customer.LastName;
            customerToEdit.Telephone = customer.Telephone;
            SaveChanges();
        }

        internal void EditBooking(Booking booking)
        {
            var bookingToEdit = Booking.Find(booking.BookingId);
            bookingToEdit.Room_Id = booking.Room_Id;
            bookingToEdit.StartDate = booking.StartDate;
            bookingToEdit.EndDate = booking.EndDate;
            SaveChanges();
        }
    }
}
