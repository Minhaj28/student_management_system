using DAL.ORM;
using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class PhDStudentService
    {
        private PhDStudentAction _phdStudentAction;

        public PhDStudentService(PhDStudentAction phdStudentAction)
        {
            _phdStudentAction = phdStudentAction;
        }
        public void ScheduleDefense()
        {
            Console.WriteLine($"PhDStudent scheduled a defense.");
        }

        public void Research()
        {
            Console.WriteLine($"PhDStudent is conducting research.");
        }
    }
}
