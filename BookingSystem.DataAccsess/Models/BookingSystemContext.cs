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

    public virtual DbSet<TrsBooking> TrsBookings { get; set; }

    public virtual DbSet<TrsParticipant> TrsParticipants { get; set; }

    public virtual DbSet<TrsResource> TrsResources { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BookingSystem;Username=postgres;Password=indocyber");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            entity.Property(e => e.Functions).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(255);
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

        modelBuilder.Entity<TrsBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TRSHistory_pkey");

            entity.ToTable("TrsBooking");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CancelledDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EmailPic)
                .HasColumnType("character varying")
                .HasColumnName("EmailPIC");
            entity.Property(e => e.Necessity).HasMaxLength(200);
            entity.Property(e => e.RecurringPattern).HasColumnType("character varying");
            entity.Property(e => e.RequestBy).HasMaxLength(250);
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.Status).HasColumnType("character varying");
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.BookCode).WithMany(p => p.TrsBookings)
                .HasForeignKey(d => d.BookCodeId)
                .HasConstraintName("FKBookCode");

            entity.HasOne(d => d.Room).WithMany(p => p.TrsBookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKRoom");
        });

        modelBuilder.Entity<TrsParticipant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TrsParticipant_pkey");

            entity.ToTable("TrsParticipant");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeletedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.IsVip).HasColumnName("IsVIP");
        });

        modelBuilder.Entity<TrsResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TrsResource_pkey");

            entity.ToTable("TrsResource");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.CreatedBy).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeletedDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ResCodeId).HasColumnName("ResCodeID");
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Book).WithMany(p => p.TrsResources)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKBook");

            entity.HasOne(d => d.ResCode).WithMany(p => p.TrsResources)
                .HasForeignKey(d => d.ResCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKResCode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
