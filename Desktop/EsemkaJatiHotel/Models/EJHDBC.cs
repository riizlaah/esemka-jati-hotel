using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    /// <summary>
    /// EJHDBC = Esemka Jati Hotel DB Context
    /// </summary>
    public class EJHDBC: DbContext
    {
        public EJHDBC() : base("name=EsemkaJatiHotel") 
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemStatus> ItemStatuses { get; set; }
        public DbSet<FoodAndDrinks> FoodAndDrinks { get; set; }
        public DbSet<FDCheckout> FDCheckouts { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationCheckOut> ReservationCheckOuts { get; set; }
        public DbSet<ReservationRequestItem> ReservationRequestItems { get; set; }
        public DbSet<ReservationRoom> ReservationRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public Employee currEmployee { get; set; } = null;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasRequired(r => r.Employee)
                .WithMany().HasForeignKey(r => r.EmployeeId).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
 
}
