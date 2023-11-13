using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innorik.Attendance.System.Application.Command.Query.Handlers
{
    public class isLateResponse : IRequest<ApiResponse>
    {
        public DateTime? Date { get; set; }
    }

    public class isLateResponseHandler : IRequestHandler<isLateResponse, ApiResponse>
    {
        public Task<ApiResponse> Handle(isLateResponse request, CancellationToken cancellationToken)
        {
            var currentDate = request.Date;
            var serverDate = DateTime.UtcNow;
            bool isCompare = currentDate > serverDate || currentDate < serverDate;
            if (isCompare == true)
            {
                var response = new ApiResponse()
                {
                    isStatus = true,
                    Message = $"You are late"
                };
                return Task.FromResult(response);
            }
            var result = new ApiResponse()
            {
                isStatus = true,
                Message = $"You are on time"
            };
            return Task.FromResult(result);
        }

    }
}
