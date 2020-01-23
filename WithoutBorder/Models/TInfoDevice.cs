using System;
using System.Collections.Generic;

namespace WithoutBorder
{
    public partial class TInfoDevice
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual TDevice IdNavigation { get; set; }
    }
}
