using AutoMapper;
using Innorik.Attendance.System.Application.Dtos;
using Innorik.Attendance.System.Domain;

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
