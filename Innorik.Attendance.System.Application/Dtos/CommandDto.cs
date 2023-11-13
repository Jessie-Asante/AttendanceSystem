namespace Innorik.Attendance.System.Application.Dtos
{
    public class CommandDto
    {
        public class CreateCheckInDto
        {
            public string? AtsFirstName { get; set; }
            public string? AtsLastName { get; set; }
            public bool AtsActive { get; set; }
            public string? AtsCheckInPicture { get; set; }
            public string? AtsCheckInPictureHeader { get; set; }


        }

        public class CreateCheckoutDto
        {
            public string? AtsFirstName { get; set; }
            public string? AtsLastName { get; set; }
            public DateTime? AtsCheckOutTime { get; set; }
            public byte[]? AtsCheckOutPicture { get; set; }
        }

       
    }
}