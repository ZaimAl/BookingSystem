using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.DataAccsess.Models;

public partial class BookingSystemContext : DbContext
{
    public BookingSystemContext()
    {
    }

    public BookingSystemContext(DbContextOptions<BookingSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MstBook> MstBooks { get; set; }

    public virtual DbSet<MstBookCode> MstBookCodes { get; set; }

    public virtual DbSet<MstLocation> MstLocations { get; set; }

    public virtual DbSet<MstMenu> MstMenus { get; set; }

    public virtual DbSet<MstResource> MstResources { get; set; }

    public virtual DbSet<MstResourceCode> MstResourceCodes { get; set; }

    public virtual DbSet<MstRole> MstRoles { get; set; }

    public virtual DbSet<MstRoleMenu> MstRoleMenus { get; set; }

    public virtual DbSet<MstRoom> MstRooms { get; set; }

    public virtual DbSet<MstRoomResource> MstRoomResources { get; set; }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BookingSystem;Username=postgres;Password=indocyber");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MstBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstBook_pkey");

            entity.ToTable("MstBook");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MstBookCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstBookCode_pkey");

            entity.ToTable("MstBookCode");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.BookingCode).HasMaxLength(20);
            entity.Property(e => e.CreateDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp(6) without time zone");
        });

        modelBuilder.Entity<MstLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstLocation_pkey");

            entity.ToTable("MstLocation");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MstMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstMenu_pkey");

            entity.ToTable("MstMenu");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Functions)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MstResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstResource_pkey");

            entity.ToTable("MstResource");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Icon).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp(6) without time zone");
        });

        modelBuilder.Entity<MstResourceCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstResourceMenu_pkey");

            entity.ToTable("MstResourceCode");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.ResourceCode).HasMaxLength(10);
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp(6) without time zone");

            entity.HasOne(d => d.Resource).WithMany(p => p.MstResourceCodes)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKResource");
        });

        modelBuilder.Entity<MstRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("MstRole");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp(6) without time zone");
        });

        modelBuilder.Entity<MstRoleMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstRoleMenu_pkey");

            entity.ToTable("MstRoleMenu");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp(6) without time zone");

            entity.HasOne(d => d.Menu).WithMany(p => p.MstRoleMenus)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMenu");

            entity.HasOne(d => d.Role).WithMany(p => p.MstRoleMenus)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKRole");
        });

        modelBuilder.Entity<MstRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstRoom_pkey");

            entity.ToTable("MstRoom");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.RoomColor).HasMaxLength(20);
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Location).WithMany(p => p.MstRooms)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FKLocation");
        });

        modelBuilder.Entity<MstRoomResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstRoomResource_pkey");

            entity.ToTable("MstRoomResource");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp(6) without time zone");

            entity.HasOne(d => d.Resource).WithMany(p => p.MstRoomResources)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKResource");

            entity.HasOne(d => d.Room).WithMany(p => p.MstRoomResources)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKRoom");
        });

        modelBuilder.Entity<MstUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("MstUser");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last Name");
            entity.Property(e => e.LoginName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(8000);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdateDate).HasColumnType("timestamp(6) without time zone");

            entity.HasOne(d => d.Role).WithMany(p => p.MstUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("UserRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
