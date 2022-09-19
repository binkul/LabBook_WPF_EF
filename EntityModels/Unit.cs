using System.Collections.Generic;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class Unit
    {
        public Unit()
        {
            MaterialList = new List<Material>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Material> MaterialList { get; set; }

    }
}
