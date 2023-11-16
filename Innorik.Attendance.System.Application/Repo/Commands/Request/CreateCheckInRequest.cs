using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Innorik.Attendance.System.Application.Dtos.CommandDto;

namespace Innorik.Attendance.System.Application.Command.Commands.Request
{
    public class CreateCheckInRequest : IRequest<ApiResponse>
    {
        public CreateCheckInDto? Create { get; set; }
    }
}
