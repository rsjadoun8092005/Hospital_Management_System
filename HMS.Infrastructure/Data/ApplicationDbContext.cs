
namespace HMS.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<DoctorSchedule> DoctorSchedules => Set<DoctorSchedule>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Medicine> Medicines => Set<Medicine>();
        public DbSet<Prescription> Prescriptions => Set<Prescription>();
        public DbSet<PrescriptionMedicine> PrescriptionMedicines => Set<PrescriptionMedicine>();
        public DbSet<LabTest> LabTests => Set<LabTest>();
        public DbSet<LabReport> LabReports => Set<LabReport>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Admission> Admissions => Set<Admission>();
        public DbSet<Discharge> Discharges => Set<Discharge>();
        public DbSet<Insurance> Insurances => Set<Insurance>();
        public DbSet<Bill> Bills => Set<Bill>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<AiAuditLog> AiAuditLogs => Set<AiAuditLog>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.IsActive = true;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //unique

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Doctor>()
                .HasIndex(d => d.LicenseNumber)
                .IsUnique();

            //decimal precision

            modelBuilder.Entity<Patient>().Property(p => p.Height).HasColumnType("decimal(5,2)");
            modelBuilder.Entity<Patient>().Property(p => p.Weight).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Doctor>().Property(d => d.ConsultationFee).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Medicine>().Property(m => m.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Room>().Property(r => r.ChargesPerDay).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Insurance>().Property(i => i.CoverageAmount).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Bill>().Property(b => b.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Bill>().Property(b => b.Discount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Bill>().Property(b => b.TaxAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Bill>().Property(b => b.NetAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Payment>().Property(p => p.Amount).HasColumnType("decimal(18,2)");

            //1-to-1 relationships
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LabReport>()
                .HasOne(lr => lr.LabTest)
                .WithOne(lt => lt.LabReport)
                .HasForeignKey<LabReport>(lr => lr.LabTestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Discharge>()
                .HasOne(d => d.Admission)
                .WithOne(a => a.Discharge)
                .HasForeignKey<Discharge>(d => d.AdmissionId)
                .OnDelete(DeleteBehavior.Cascade);

            //1-to-many relationships

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany()
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany()
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Admission>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Admission>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
