using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int StudentEnrollmentId { get; set; }
        public string AttendanceDate { get; set; }
        public string Status { get; set; }
        public Attendance()
        {

        }
        public Attendance(int studentEnrollmentId, string attendanceDate, string status)
        {
            StudentEnrollmentId = studentEnrollmentId;
            AttendanceDate = attendanceDate;
            Status = status;
        }
    }
}
