using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innorik.Attendance.System.Application.Command.Commands.Handlers
{
    public class ValidateDateTime
    {
        public ApiResponse ValidDate(DateTime currentDate)
        {

            var serverDate = DateTime.UtcNow;
            bool isCompare = currentDate > serverDate || currentDate < serverDate;
            if (isCompare == true)
            {
                var response = new ApiResponse()
                {
                    IsSuccessful = true,
                    Message = $"You are late"
                };
                return response;
            }
            var result = new ApiResponse()
            {
                IsSuccessful = true,
                Message = $"You are on time"
            };
            return result;
        }
    }
}
