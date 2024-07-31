using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ExamResult
    {
        public int ResultId { get; set; }
        public int ExamId { get; set; }
        public int StudentID { get; set; }
        public string Score { get; set; }
        public ExamResult()
        {

        }
        public ExamResult(int examId, int studentID, string score)
        {
            ExamId = examId;
            StudentID = studentID;
            Score = score;
        }
    }
}
