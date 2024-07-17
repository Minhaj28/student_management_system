using DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class PostgraduateStudentService
    {
        private PostgraduateStudentAction _postaduateStudentAction;

        public PostgraduateStudentService(PostgraduateStudentAction postgraduateStudentAction)
        {
            _postaduateStudentAction = postgraduateStudentAction;
        }
        public void SubmitThesis()
        {
            Console.WriteLine($"PostgraduateStudent submitted a thesis.");
        }
    }
}
