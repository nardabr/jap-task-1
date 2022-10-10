using Microsoft.EntityFrameworkCore;

namespace jap_task.Dtos.Selection
{
    [Keyless]
    public class GetSelectionsSuccesRatesDto
    {
        public string SelectionName { get; set; }
        public string ProgramName { get; set; }
        public double SelectionSuccessRate { get; set; }
    }
}
