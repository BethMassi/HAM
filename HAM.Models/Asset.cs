using System;
using System.Collections.Generic;

namespace HAM.Models
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
        public string SerialNumber { get; set; }
        public string Url { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? Quantity { get; set; }
        public bool? DrawingsAvailable { get; set; }
        public string Notes { get; set; }
        public int CategoryAsset { get; set; }
        public int LocationAsset { get; set; }
        public int? AssetServiceCompany1 { get; set; }
        public ServiceCompany AssetServiceCompany1Navigation { get; set; }
        public Category CategoryAssetNavigation { get; set; }
        public Location LocationAssetNavigation { get; set; }
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
