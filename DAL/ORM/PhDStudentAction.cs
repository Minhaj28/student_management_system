using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.ORM
{
    public class PhDStudentAction
    {
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
