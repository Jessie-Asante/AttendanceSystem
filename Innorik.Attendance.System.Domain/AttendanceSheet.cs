using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innorik.Attendance.System.Domain
{
    public class AttendanceSheet
    {
        public int AtsIDpk { get; set; }
        public string? AtsFirstName { get; set; }
        public string? AtsLastName { get; set; }
        public DateTime? AtsCheckInTime { get; set; }
        public bool AtsActive { get; set; }
        public string? AtsCheckInPicture { get; set; }
        public string? AtsCheckInPictureHeader { get; set; }
        public DateTime? AtsCheckOutTime { get; set; }
        public byte[]? AtsCheckOutPicture { get; set; }
        public string? AtsCheckOutPictureHeader { get; set; }
    }
}
