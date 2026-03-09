using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

public partial class EsemkaJatiHotelContext : DbContext
{
    public EsemkaJatiHotelContext()
    {
    }

    public EsemkaJatiHotelContext(DbContextOptions<EsemkaJatiHotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Fdcheckout> Fdcheckouts { get; set; }

    public virtual DbSet<FoodAndDrink> FoodAndDrinks { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemStatus> ItemStatuses { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationCheckOut> ReservationCheckOuts { get; set; }

    public virtual DbSet<ReservationRequestItem> ReservationRequestItems { get; set; }

    public virtual DbSet<ReservationRoom> ReservationRooms { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Integrated Security=true;Database=EsemkaJatiHotel");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Customers");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Employees");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees).HasConstraintName("FK_dbo.Employees_dbo.Jobs_JobId");
        });

        modelBuilder.Entity<Fdcheckout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.FDCheckouts");

            entity.HasOne(d => d.Employee).WithMany(p => p.Fdcheckouts).HasConstraintName("FK_dbo.FDCheckouts_dbo.Employees_EmployeeId");

            entity.HasOne(d => d.Fd).WithMany(p => p.Fdcheckouts).HasConstraintName("FK_dbo.FDCheckouts_dbo.FoodAndDrinks_FDId");

            entity.HasOne(d => d.ReservationRoom).WithMany(p => p.Fdcheckouts).HasConstraintName("FK_dbo.FDCheckouts_dbo.ReservationRooms_ReservationRoomId");
        });

        modelBuilder.Entity<FoodAndDrink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.FoodAndDrinks");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Items");
        });

        modelBuilder.Entity<ItemStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ItemStatus");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Jobs");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Reservations");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations).HasConstraintName("FK_dbo.Reservations_dbo.Customers_CustomerId");

            entity.HasOne(d => d.Employee).WithMany(p => p.Reservations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Reservations_dbo.Employees_EmployeeId");
        });

        modelBuilder.Entity<ReservationCheckOut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ReservationCheckOuts");

            entity.HasOne(d => d.Item).WithMany(p => p.ReservationCheckOuts).HasConstraintName("FK_dbo.ReservationCheckOuts_dbo.Items_ItemId");

            entity.HasOne(d => d.ItemStatus).WithMany(p => p.ReservationCheckOuts).HasConstraintName("FK_dbo.ReservationCheckOuts_dbo.ItemStatus_ItemStatusId");

            entity.HasOne(d => d.ReservationRoom).WithMany(p => p.ReservationCheckOuts).HasConstraintName("FK_dbo.ReservationCheckOuts_dbo.ReservationRooms_ReservationRoomId");
        });

        modelBuilder.Entity<ReservationRequestItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ReservationRequestItems");

            entity.HasOne(d => d.Item).WithMany(p => p.ReservationRequestItems).HasConstraintName("FK_dbo.ReservationRequestItems_dbo.Items_ItemId");

            entity.HasOne(d => d.ReservationRoom).WithMany(p => p.ReservationRequestItems).HasConstraintName("FK_dbo.ReservationRequestItems_dbo.ReservationRooms_ReservationRoomId");
        });

        modelBuilder.Entity<ReservationRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ReservationRooms");

            entity.HasOne(d => d.Reservation).WithMany(p => p.ReservationRooms).HasConstraintName("FK_dbo.ReservationRooms_dbo.Reservations_ReservationId");

            entity.HasOne(d => d.Room).WithMany(p => p.ReservationRooms).HasConstraintName("FK_dbo.ReservationRooms_dbo.Rooms_RoomId");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Rooms");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms).HasConstraintName("FK_dbo.Rooms_dbo.RoomTypes_RoomTypeId");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.RoomTypes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
