using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innorik.Attendance.System.Application.Common
{
    public class Utils
    {
        public static byte[] Conversion(string picture)
        {
            byte[] imageConvert = Convert.FromBase64String(picture);
            return imageConvert;
        }

    }
}
