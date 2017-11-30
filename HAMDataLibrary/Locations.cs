using System;
using System.Collections.Generic;

namespace HAMDataLibrary
{
    public partial class Locations
    {
        public Locations()
        {
            Assets = new HashSet<Assets>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<Assets> Assets { get; set; }
    }
}
