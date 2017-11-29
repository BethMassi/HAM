using System;
using System.Collections.Generic;

namespace HAMWeb.Models
{
    public partial class Pictures
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }
        public bool? IsDefaultPicture { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public byte[] RowVersion { get; set; }
        public int? PictureAsset { get; set; }
        public int? PictureMaintanceLog { get; set; }

        public Assets PictureAssetNavigation { get; set; }
        public MaintenanceLogs PictureMaintanceLogNavigation { get; set; }
    }
}
