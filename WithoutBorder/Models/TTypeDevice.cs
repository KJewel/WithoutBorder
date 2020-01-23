using System;
using System.Collections.Generic;

namespace WithoutBorder
{
    public partial class TTypeDevice
    {
        public TTypeDevice()
        {
            TDevice = new HashSet<TDevice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TDevice> TDevice { get; set; }
    }
}
