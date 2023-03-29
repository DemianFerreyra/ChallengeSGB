using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChallengeSGB.Models;

public partial class ChallengeContext : DbContext
{
    public ChallengeContext()
    {
    }

    public ChallengeContext(DbContextOptions<ChallengeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Encuesta> Encuestas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-6U3PTB2; Database=Challenge; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Encuesta>(entity =>
        {
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
