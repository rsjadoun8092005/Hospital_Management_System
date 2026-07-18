using HMS.Application.Commands;
using HMS.Core.Common;
using HMS.Core.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HMS.Application.Handlers
{
    public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;

        public CancelAppointmentCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<ResponseModel<bool>> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == request.AppointmentId
                                       && a.PatientId == request.PatientId, cancellationToken);

            if (appointment == null)
            {
                return ResponseModel<bool>.FailureResponse("Appointment not found or you do not have permission to cancel it.");
            }

            if (appointment.Status == "Completed" || appointment.Status == "Cancelled")
            {
                return ResponseModel<bool>.FailureResponse($"Appointment cannot be cancelled because it is already {appointment.Status.ToLower()}.");
            }

            appointment.Status = "Cancelled";
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseModel<bool>.SuccessResponse(true, "Appointment cancelled successfully.");
        }
    }
}