using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class MaterialFunction : INotifyPropertyChanged
    {
        public MaterialFunction()
        {
            MaterialList = new List<Material>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Material> MaterialList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
