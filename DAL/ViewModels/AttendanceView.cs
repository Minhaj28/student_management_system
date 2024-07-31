using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class AttendanceView
    {
        public int AttendanceId { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
        public string AttendanceDate { get; set; }
        public string Status { get; set; }
        public AttendanceView()
        {

        }
       /* public AttendanceView(string courseName, string attendanceDate, string status)
        {
            CourseName = courseName;
            AttendanceDate = attendanceDate;
            Status = status;
        }*/
    }
}
