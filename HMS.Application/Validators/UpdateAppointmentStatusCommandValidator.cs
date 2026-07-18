namespace HMS.Application.Validators
{
    public class UpdateAppointmentStatusCommandValidator : AbstractValidator<UpdateAppointmentStatusCommand>
    {
        public UpdateAppointmentStatusCommandValidator()
        {
            RuleFor(x => x.AppointmentId).NotEmpty().WithMessage("Appointment Id is required.");
            RuleFor(x => x.DoctorId).NotEmpty().WithMessage("Doctor Id is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(s => s == "Completed" || s == "No-Show" || s == "In-Progress")
                .WithMessage("Invalid Status. Allowed values: In-Progress, Completed, No-Show.");
        }
    }
}
