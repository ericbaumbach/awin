using System.Collections.Generic;

namespace Awin_Test
{
    public class Commission
    {
        public int advertiser { get; set; }
        public int publisher { get; set; }
        public List<CommissionGroup> commissionGroups { get; set; }
    }
}