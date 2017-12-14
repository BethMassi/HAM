using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HAMDataLibrary
{
    public partial class ServiceCompany
    {
        public ServiceCompany()
        {
            Assets = new HashSet<Asset>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public ICollection<Asset> Assets { get; set; }
        //TODO:Let's figure out the audit trail later 
        //public string CreatedBy { get; set; }
        //public DateTimeOffset? Created { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTimeOffset? Modified { get; set; }
        //public byte[] RowVersion { get; set; }
    }
}
