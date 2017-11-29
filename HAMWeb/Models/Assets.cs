using System;
using System.Collections.Generic;

namespace HAMWeb.Models
{
    public partial class Assets
    {
        public Assets()
        {
            MaintenanceLogs = new HashSet<MaintenanceLogs>();
            Pictures = new HashSet<Pictures>();
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
        public string CreatedBy { get; set; }
        public DateTimeOffset? Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public byte[] RowVersion { get; set; }
        public int CategoryAsset { get; set; }
        public int LocationAsset { get; set; }
        public int? AssetServiceCompany1 { get; set; }

        public ServiceCompanies AssetServiceCompany1Navigation { get; set; }
        public Categories CategoryAssetNavigation { get; set; }
        public Locations LocationAssetNavigation { get; set; }
        public ICollection<MaintenanceLogs> MaintenanceLogs { get; set; }
        public ICollection<Pictures> Pictures { get; set; }
    }
}
