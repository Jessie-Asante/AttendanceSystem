using AutoMapper;
using Innorik.Attendance.System.Application.Command.Query.Request;
using Innorik.Attendance.System.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Innorik.Attendance.System.Application.Dtos.QueryDto;

namespace Innorik.Attendance.System.Application.Command.Query.Handlers
{
    public class GetTodaysLoginsCommandHandler : IRequestHandler<GetTodaysLoginsRequest, IReadOnlyList<GetAllCheckInDto>>
    {
        private readonly IGenericRepository<GetAllCheckInDto> _repository;
        private readonly IMapper _mapper;
        public GetTodaysLoginsCommandHandler(IGenericRepository<GetAllCheckInDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<GetAllCheckInDto>> Handle(GetTodaysLoginsRequest request, CancellationToken cancellationToken)
        {

            var response = await _repository.GetAll($"EXEC [dbo].[spcGetAllTodaysCheckIn] @search = {request.SearchText}");

            return _mapper.Map<IReadOnlyList<GetAllCheckInDto>>(response);
        }
    }
}
