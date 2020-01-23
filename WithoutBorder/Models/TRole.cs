using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WithoutBorder
{
    public partial class TRole
    {
        public TRole()
        {
            TUsers = new HashSet<TUsers>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        [NotMapped]
        public int IdRole
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }

        public virtual ICollection<TUsers> TUsers { get; set; }
    }
}
