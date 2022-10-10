using Microsoft.EntityFrameworkCore;

namespace jap_task.Dtos.Selection
{
    [Keyless]
    public class GetOverallSuccesRateDto
    {
        public double OverallSuccessRate { get; set; }
    }
}

