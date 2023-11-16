using AutoMapper;
using Innorik.Attendance.System.Application.Command.Commands.Request;
using Innorik.Attendance.System.Application.Common;
using Innorik.Attendance.System.Domain;
using Innorik.Attendance.System.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Innorik.Attendance.System.Application.Command.Commands.Handlers
{
    public class CreateCheckOutRequestHandler : IRequestHandler<CreateCheckOutRequest, ApiResponse>
    {
        private readonly IGenericRepository<AttendanceSheet> _repository;
        private readonly IMapper _mapper;

        public CreateCheckOutRequestHandler(IGenericRepository<AttendanceSheet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateCheckOutRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<AttendanceSheet>(request.CheckoutRequest);
            var newImage = Utils.Conversion(dto.AtsCheckOutPicture);
            var response = await _repository.Update($"EXEC [dbo].[spcCreateCheckOut] @atsIDpk = {request.Id}, @atsCheckOutPicture = {newImage}, @atsCheckOutPictureHeader = {dto.AtsCheckOutPictureHeader}");

            switch(response > 0)
            {
                case true:
                    return new ApiResponse()
                    {
                        Id = request.Id,
                        IsSuccessful = true,
                        Message = $"Record Saved Successfully"
                    };
                case false:
                    return new ApiResponse()
                    {
                        Id = request.Id,
                        IsSuccessful = false,
                        Message = $"Record Failed to Save"
                    };
            }

        }
    }
}
