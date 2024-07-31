using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ResultView
    {
        public int ResultId { get; set; }
        public int ExamId { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
        public string Score { get; set; }
        public ResultView()
        {

        }
    }
}
