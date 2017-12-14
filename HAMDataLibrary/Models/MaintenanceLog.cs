using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HAMDataLibrary
{
    public partial class MaintenanceLog
    {
        public MaintenanceLog()
        {
            Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }
        [Display(Name = "Maintenance Date")]
        public DateTime MaintenanceDate { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Completed?")]
        public bool? IsCompleted { get; set; }        
        public int MaintanceLogAsset { get; set; }
        [Display(Name = "Asset")]
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
