using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ExamView
    {
        public int ExamId { get; set; }
        public string CourseName { get; set; }
        public string ExamDate { get; set; }
        public string ExamType { get; set; }
        public ExamView()
        {

        }
        public ExamView(string courseName, string examDate, string examType)
        {
            CourseName = courseName;
            ExamDate = examDate;
            ExamType = examType;
        }
    }
}
