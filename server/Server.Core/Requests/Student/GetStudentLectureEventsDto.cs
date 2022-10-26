using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Requests.Student
{
    public class GetStudentLectureEventsDto
    {
        public int DoneByCandidate { get; set; }
        public string StatusByCandidate { get; set; }
    }
}
