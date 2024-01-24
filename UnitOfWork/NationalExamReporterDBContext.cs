using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NationalExamReporter.Entities;
using NationalExamReporter.Utils;

namespace NationalExamReporter.UnitOfWork
{
    public partial class NationalExamReporterDBContext : DbContext
    {
        private IConfiguration? _config;

        public NationalExamReporterDBContext()
        {
            InitializeObjects();
        }

        public NationalExamReporterDBContext(DbContextOptions<NationalExamReporterDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SchoolYear>? SchoolYears { get; set; }
        public virtual DbSet<Score>? Scores { get; set; }
        public virtual DbSet<Student>? Students { get; set; }
        public virtual DbSet<Subject>? Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _config!
                    .GetSection(
                    "ConnectionStrings:NationalExamReporterDB")!
                    .Value!;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolYear>(entity =>
            {
                entity.ToTable("SchoolYear");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("Score");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ScorePerSubject).HasColumnName("ScorePerSubject");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKScore777833");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKScore41851");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StudentCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.SchoolYear)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SchoolYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStudent209903");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void InitializeObjects()
        {
            _config = ConfigurationUtils.GetConfiguration();
        }
    }
}