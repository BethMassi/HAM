using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HAMDataLibrary
{
    public partial class Picture
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }
        [Display(Name = "Default Picture?")]
        public bool? IsDefaultPicture { get; set; }
        public int? PictureAsset { get; set; }
        public int? PictureMaintanceLog { get; set; }
        [Display(Name = "Asset")]
        public Asset PictureAssetNavigation { get; set; }
        [Display(Name = "Maintenance Log")]
        public MaintenanceLog PictureMaintanceLogNavigation { get; set; }

        //TODO:Let's figure out the audit trail later 
        //public string CreatedBy { get; set; }
        //public DateTimeOffset? Created { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTimeOffset? Modified { get; set; }
        //public byte[] RowVersion { get; set; }
    }
}
