using System;
using System.Collections.Generic;

namespace HAMWeb.Models
{
    public partial class MaintenanceLogs
    {
        public MaintenanceLogs()
        {
            Pictures = new HashSet<Pictures>();
        }

        public int Id { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Notes { get; set; }
        public bool? IsCompleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public byte[] RowVersion { get; set; }
        public int MaintanceLogAsset { get; set; }

        public Assets MaintanceLogAssetNavigation { get; set; }
        public ICollection<Pictures> Pictures { get; set; }
    }
}
