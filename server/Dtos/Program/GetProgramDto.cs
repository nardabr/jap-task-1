using jap_task.Dtos.Selection;
using server.Dtos.Selection;

namespace jap_task.Dtos.Program
{
    public class GetProgramDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
