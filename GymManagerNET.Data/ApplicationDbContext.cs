using GymManager.Data;
using GymManagerNET.Core.Models;
using GymManagerNET.Core.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagerNET.Data;

public class ApplicationDbContext : IdentityDbContext<DefaultEmployee>
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<FingerPrint> FingerPrint { get; set; }
    public DbSet<FitnessRoom> FitnessRooms { get; set; }
    public DbSet<RoomBooking> RoomBookings { get; set; }
    public DbSet<Activity> Activities { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subscription>()
            .HasOne(p => p.User)
            .WithMany(b => b.Subscriptions)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<FingerPrint>()
            .HasOne(p => p.User)
            .WithMany(b => b.FingerPrint)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<RoomBooking>()
            .HasOne(p => p.Activity)
            .WithMany(b => b.Bookings)
            .HasForeignKey(p => p.ActivityId);

        modelBuilder.Entity<RoomBooking>()
            .HasOne(p => p.Room)
            .WithMany(x => x.Bookings )
            .HasForeignKey(p => p.RoomId);

        base.OnModelCreating(modelBuilder);
    }
}

