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
        public DateTime Date { get; set; }
    }

    public class isLateResponseHandler : IRequestHandler<isLateResponse, ApiResponse>
    {
        public Task<ApiResponse> Handle(isLateResponse request, CancellationToken cancellationToken)
        {
            var currentDate = request.Date;
            var validDate = TimeSpan.Parse("08:00");
            DateTime passedDate = DateTime.Today+validDate;
            bool isCompare = currentDate > passedDate;
            if (isCompare == true)
            {
                var response = new ApiResponse()
                {
                    IsSuccessful = true,
                    Message = $"You are late"
                };
                return Task.FromResult(response);
            }
               
            var results = new ApiResponse()
            {
                IsSuccessful = true,
                Message = $"You are on time"
            };
            return Task.FromResult(results);

        }

    }
}
