using System;
using System.Collections.Generic;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class Currency
    {
        public Currency()
        {
            MaterialList = new HashSet<Material>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Material> MaterialList { get; set; }

    }
}
