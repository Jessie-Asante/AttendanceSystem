using AutoMapper;
using Innorik.Attendance.System.Application.Command.Commands.Request;
using Innorik.Attendance.System.Domain;
using Innorik.Attendance.System.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innorik.Attendance.System.Application.Command.Commands.Handlers
{
    public class CreateCheckInCommandHandler : IRequestHandler<CreateCheckInRequest, ApiResponse>
    {
        private readonly IGenericRepository<AttendanceSheet> _repository;
        private readonly IMapper _mapper;
        public CreateCheckInCommandHandler(IGenericRepository<AttendanceSheet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateCheckInRequest request, CancellationToken cancellationToken)
        {
            var dto = request.Create;
            var entity = new AttendanceSheet();
            var map = _mapper.Map(dto, entity);
            var newImage = Conversion(dto.AtsCheckInPicture);
            FormattableString query = $"[dbo].[spcCreateCheckIn] @atsFirstName = {map.AtsFirstName}, @atsLastName = {map.AtsLastName}, @atsActive = {map.AtsActive}, @atsCheckInPicture = {newImage}, @atsCheckInPictureHeader = {map.AtsCheckInPictureHeader}";
            var response = await _repository.Adds(query);
            if (response > 0)
                return new ApiResponse()
                {
                    isStatus = true,
                    Message = $"record saved Successfully"
                };
            return new ApiResponse()
            {
                isStatus = false,
                Message = $"record failed to save"
            };
        }
        private byte[] Conversion(string picture)
        {
            byte[] imageConvert = Convert.FromBase64String(picture);
            return imageConvert;
        }
    }

}
    

