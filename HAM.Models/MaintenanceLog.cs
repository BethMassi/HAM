using System;
using System.Collections.Generic;

namespace HAM.Models
{
    public partial class MaintenanceLog
    {
        public MaintenanceLog()
        {
            Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Notes { get; set; }
        public bool? IsCompleted { get; set; }        
        public int MaintanceLogAsset { get; set; }
        public Asset MaintanceLogAssetNavigation { get; set; }
        public ICollection<Picture> Pictures { get; set; }

        //TODO:Let's figure out the audit trail later 
        //public string CreatedBy { get; set; }
        //public DateTimeOffset? Created { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTimeOffset? Modified { get; set; }
        //public byte[] RowVersion { get; set; }

    }
}
