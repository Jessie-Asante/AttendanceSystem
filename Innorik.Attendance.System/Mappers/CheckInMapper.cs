using AutoMapper;
using Innorik.Attendance.System.Domain;
using static Innorik.Attendance.System.Application.Dtos.CommandDto;

namespace Innorik.Attendance.System.Api.Mappers
{
    public class CheckInMapper:Profile
    {
        public CheckInMapper()
        {
            CreateMap<CreateCheckInDto, AttendanceSheet>().ReverseMap();
            CreateMap<CreateCheckoutDto, AttendanceSheet>().ReverseMap();
        }
    }
}
