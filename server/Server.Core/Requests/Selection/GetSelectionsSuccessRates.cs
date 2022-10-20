using Microsoft.EntityFrameworkCore;

namespace Server.Core.Requests.Selection
{
    [Keyless]
    public class GetSelectionsSuccesRatesDto
    {
        public string SelectionName { get; set; }
        public string ProgramName { get; set; }
        public double SelectionSuccessRate { get; set; }
    }
}
