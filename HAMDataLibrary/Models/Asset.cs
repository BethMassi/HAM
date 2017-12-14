using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HAMDataLibrary
{
    public partial class Asset
    {
        public Asset()
        {
            MaintenanceLogs = new HashSet<MaintenanceLog>();
            Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public string Url { get; set; }
        [Display(Name = "Purchase Date")]
        public DateTime? PurchaseDate { get; set; }
        [Display(Name = "Purchase Price")]
        public decimal? PurchasePrice { get; set; }
        public int? Quantity { get; set; }
        [Display(Name = "Drawings?")]
        public bool? DrawingsAvailable { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Category")]
        public int CategoryAsset { get; set; }
        [Display(Name = "Location")]
        public int LocationAsset { get; set; }
        [Display(Name = "Service Company")]
        public int? AssetServiceCompany1 { get; set; }
        [Display(Name = "Service Company")]
        public ServiceCompany AssetServiceCompany1Navigation { get; set; }
        [Display(Name = "Category")]
        public Category CategoryAssetNavigation { get; set; }
        public Location LocationAssetNavigation { get; set; }
        [Display(Name = "Maintenance Logs")]
        public ICollection<MaintenanceLog> MaintenanceLogs { get; set; }
        public ICollection<Picture> Pictures { get; set; }

        //TODO:Let's figure out the audit trail later 
        //public string CreatedBy { get; set; }
        //public DateTimeOffset? Created { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTimeOffset? Modified { get; set; }
        //public byte[] RowVersion { get; set; }
    }
}
