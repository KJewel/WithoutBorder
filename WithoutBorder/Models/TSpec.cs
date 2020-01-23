using System;
using System.Collections.Generic;

namespace WithoutBorder
{
    public partial class TSpec
    {
        public int IdUser { get; set; }
        public string Title { get; set; }

        public virtual TUsers IdUserNavigation { get; set; }
    }
}
