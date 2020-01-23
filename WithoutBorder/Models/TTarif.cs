using System;
using System.Collections.Generic;

namespace WithoutBorder
{
    public partial class TTarif
    {
        public TTarif()
        {
            TContract = new HashSet<TContract>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public virtual ICollection<TContract> TContract { get; set; }
    }
}
