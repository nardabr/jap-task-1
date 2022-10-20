using Microsoft.EntityFrameworkCore;

namespace Server.Core.Requests.Selection
{
    [Keyless]
    public class GetOverallSuccesRateDto
    {
        public double OverallSuccessRate { get; set; }
    }
}

