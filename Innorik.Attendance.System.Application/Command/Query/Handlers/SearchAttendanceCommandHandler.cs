using Innorik.Attendance.System.Application.Command.Query.Request;
using MediatR;
using AutoMapper;
using Innorik.Attendance.System.Infrastructure.Persistence;
using static Innorik.Attendance.System.Application.Dtos.QueryDto;

namespace Innorik.Attendance.System.Application.Command.Query.Handlers
{
    public class SearchAttendanceCommandHandler : IRequestHandler<SearchAttendanceRequest, IEnumerable<GetAllCheckInDto>>
    {
        private readonly IGenericRepository<GetAllCheckInDto> _repository;
        private readonly IMapper _mapper;

        public SearchAttendanceCommandHandler(IGenericRepository<GetAllCheckInDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllCheckInDto>> Handle(SearchAttendanceRequest request, CancellationToken cancellationToken)
        {

            FormattableString query = $"[dbo].[spcGetAllCheckIn] @search ={request.Search}";

            var response = await _repository.GetAll(query);
            if (response == null)
                return null;
            return _mapper.Map<IEnumerable<GetAllCheckInDto>>(response);

        }
    }
}
