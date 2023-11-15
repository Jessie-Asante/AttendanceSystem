using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Innorik.Attendance.System.Application.Dtos.QueryDto;

namespace Innorik.Attendance.System.Application.Command.Query.Request
{
    public class GetTodaysLoginsRequest : IRequest<IReadOnlyList<GetAllCheckInDto>>
    {
        public string? SearchText { get; set; }
    }
}
