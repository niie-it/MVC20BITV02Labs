using System;
using System.Collections.Generic;

namespace Lab08.Data
{
    public partial class Supplier
    {
        public Supplier()
        {
            Parts = new HashSet<Part>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsImporter { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
