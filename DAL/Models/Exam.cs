using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public string ExamDate { get; set; }
        public string ExamType { get; set; }
        public Exam()
        {

        }
        public Exam(int courseId, string examDate, string examType)
        {
            CourseId = courseId;
            ExamDate = examDate;
            ExamType = examType;
        }
    }
}
