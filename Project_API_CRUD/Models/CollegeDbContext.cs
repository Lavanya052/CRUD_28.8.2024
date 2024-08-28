using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_API_CRUD.Models;

public partial class CollegeDbContext : DbContext  //extend or inherite
{
    public CollegeDbContext(DbContextOptions<CollegeDbContext> options)  // connection str as parameter
        : base(options)
    {
    }


    //property can be overridden by derived classes and is accessible from outside the class
    public virtual DbSet<Students> Student { get; set; }  //db<class>  tablename {get;set;}



    protected override void OnModelCreating(ModelBuilder modelBuilder) // to find DB schema
    {
        modelBuilder.Entity<Students>(entity => // refering student table 
        {
            entity
                .HasKey(e => e.Id).HasName("PK__student__3213E83F799D5EC5"); //indicate PK

            entity.Property(e => e.Gender)
                .HasMaxLength(10) // constraints
                .IsUnicode(false)
                .HasColumnName("gender")
                .IsRequired();
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MarkPer)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("mark_per")
                .IsRequired();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name")
                .IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    // additional model configuration can be added in a partial method implementation.
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
