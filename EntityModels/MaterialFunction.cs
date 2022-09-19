using System;
using System.Collections.Generic;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class MaterialFunction
    {
        public MaterialFunction()
        {
            MaterialList = new List<Material>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Material> MaterialList { get; set; }
    }
}
