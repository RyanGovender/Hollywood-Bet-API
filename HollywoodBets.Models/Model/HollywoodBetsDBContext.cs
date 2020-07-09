using System;
using HollywoodBets.Models.Custom_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HollywoodBets.Models.Model
{
    public partial class HollywoodBetsDBContext : DbContext
    {
        public HollywoodBetsDBContext()
        {
        }

        public HollywoodBetsDBContext(DbContextOptions<HollywoodBetsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllowedTournamentBets> AllowedTournamentBets { get; set; }
        public virtual DbSet<BetType> BetType { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Market> Market { get; set; }
        public virtual DbSet<MarketBetType> MarketBetType { get; set; }
        public virtual DbSet<SportCountry> SportCountry { get; set; }
        public virtual DbSet<SportTournament> SportTournament { get; set; }
        public virtual DbSet<SportTree> SportTree { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<TournamentBetType> TournamentBetType { get; set; }
        public virtual DbSet<BetSlip> BetSlip { get; set; }
        public virtual DbSet<MarketOdds> MarketOdds { get; set; }
        public virtual DbSet<TestTable> TestTables { get; set;}

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;initial catalog=HollywoodBetsDB;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllowedTournamentBets>(entity =>
            {
                entity.HasKey(e => e.AllowedBetId);

                entity.Property(e => e.AllowedBetId)
                    .HasColumnName("AllowedBetID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Market)
                    .WithMany(p => p.AllowedTournamentBets)
                    .HasForeignKey(d => d.MarketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllowedTournamentBets_Market");

                entity.HasOne(d => d.TournamentBetType)
                    .WithMany(p => p.AllowedTournamentBets)
                    .HasForeignKey(d => d.TournamentBetTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllowedTournamentBets_TournamentBetType");
            });

            modelBuilder.Entity<BetType>(entity =>
            {
                entity.Property(e => e.BetTypeId).ValueGeneratedNever();

                entity.Property(e => e.BetTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IconCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId).ValueGeneratedNever();

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventName).IsRequired();

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Tournament");
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.Property(e => e.MarketId).ValueGeneratedNever();

                entity.Property(e => e.MarketName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MarketBetType>(entity =>
            {
                entity.Property(e => e.MarketBetTypeId).ValueGeneratedNever();

                entity.HasOne(d => d.BetType)
                    .WithMany(p => p.MarketBetType)
                    .HasForeignKey(d => d.BetTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketBetType_BetType");

                entity.HasOne(d => d.Market)
                    .WithMany(p => p.MarketBetType)
                    .HasForeignKey(d => d.MarketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketBetType_Market");
            });

            modelBuilder.Entity<SportCountry>(entity =>
            {
                entity.Property(e => e.SportCountryId).ValueGeneratedNever();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.SportCountry)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SportCountry_Country");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.SportCountry)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SportCountry_SportTree");
            });

            modelBuilder.Entity<SportTournament>(entity =>
            {
                entity.Property(e => e.SportTournamentId).ValueGeneratedNever();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.SportTournament)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SportTournament_Country");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.SportTournament)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SportTournament_SportTree");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.SportTournament)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SportTournament_Tournament");
            });

            modelBuilder.Entity<SportTree>(entity =>
            {
                entity.HasKey(e => e.SportId);

                entity.Property(e => e.SportId).ValueGeneratedNever();

                entity.Property(e => e.LogoUrl)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SportName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.TournamentId).ValueGeneratedNever();

                entity.Property(e => e.TournamentName).IsRequired();
            });

            modelBuilder.Entity<TournamentBetType>(entity =>
            {
                entity.Property(e => e.TournamentBetTypeId).ValueGeneratedNever();

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentBetType)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentBetType_Tournament");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
