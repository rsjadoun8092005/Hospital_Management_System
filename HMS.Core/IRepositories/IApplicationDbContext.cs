
namespace HMS.Core.IRepositories
{
    public interface IApplicationDbContext
    {
        DbSet<Role> Roles { get; }
        DbSet<User> Users { get; }
        DbSet<Address> Addresses { get; }
        DbSet<Department> Departments { get; }
        DbSet<Doctor> Doctors { get; }
        DbSet<DoctorSchedule> DoctorSchedules { get; }
        DbSet<Patient> Patients { get; }
        DbSet<Appointment> Appointments { get; }

        DbSet<Medicine> Medicines { get; }
        DbSet<Prescription> Prescriptions { get; }
        DbSet<PrescriptionMedicine> PrescriptionMedicines { get; }

        DbSet<LabTest> LabTests { get; }
        DbSet<LabReport> LabReports { get; }

        DbSet<Room> Rooms { get; }
        DbSet<Admission> Admissions { get; }
        DbSet<Discharge> Discharges { get; }

        DbSet<Insurance> Insurances { get; }
        DbSet<Bill> Bills { get; }
        DbSet<Payment> Payments { get; }
        DbSet<Notification> Notifications { get; }
        DbSet<AiAuditLog> AiAuditLogs { get; }
        DbSet<AuditLog> AuditLogs { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
