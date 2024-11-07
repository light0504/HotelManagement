using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelManagement.DAL.Entities;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceDetail> ServiceDetails { get; set; }

    public virtual DbSet<Entities.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

        return strConn;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Member__0CF04B381C6B8F8E");

            entity.ToTable("Member");

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomNumber).HasName("PK__Room__AE10E07B4223FD68");

            entity.ToTable("Room");

            entity.Property(e => e.RoomNumber).ValueGeneratedNever();
            entity.Property(e => e.RoomStatus)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EA40566E75");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<ServiceDetail>(entity =>
        {
            entity.HasKey(e => e.ServiceDetailId).HasName("PK__ServiceD__6F80952C58208358");

            entity.ToTable("ServiceDetail");

            entity.Property(e => e.ServiceDetailId).HasColumnName("ServiceDetailID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.ServiceDetails)
                .HasForeignKey(d => d.RoomNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceDe__RoomN__5441852A");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceDetails)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceDe__Servi__534D60F1");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__7C6949D160A8D18C");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.MemberName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Member).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task__MemberID__4D94879B");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.RoomNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Task__RoomNumber__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
