using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Innorik.Attendance.System.Application.Dtos.QueryDto;

namespace Innorik.Attendance.System.Application.Command.Query.Request
{
    public class SearchAttendanceRequest : IRequest<IEnumerable<GetAllCheckInDto>>
    {
        public string? Search { get; set; } = null;
        public DateTime? checkInDate { get; set; } = null;
        public DateTime? checkOutDate { get; set; } = null;
        
    }
}
