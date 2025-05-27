using System;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Wedding> Weddings { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Guest> Guests { get; set; } = null!;
    public DbSet<GuestList> GuestLists { get; set; } = null!;
    public DbSet<ExpenseItem> ExpenseItems { get; set; } = null!;
    public DbSet<ExpenseList> ExpenseLists { get; set; } = null!;
    public DbSet<Photo> Photos { get; set; } = null!;
    public DbSet<ToDoTask> ToDoTasks { get; set; } = null!;
    public DbSet<ToDoList> ToDoLists { get; set; } = null!;




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<WeddingVendor>()
            .HasKey(wv => new { wv.WeddingId, wv.VendorId });

        modelBuilder.Entity<WeddingVendor>()
            .HasOne(wv => wv.Wedding)
            .WithMany(w => w.SelectedVendors)
            .HasForeignKey(wv => wv.WeddingId);

        modelBuilder.Entity<WeddingVendor>()
            .HasOne(wv => wv.Vendor)
            .WithMany(v => v.AssignedToWeddings)
            .HasForeignKey(wv => wv.VendorId);

    }
}
