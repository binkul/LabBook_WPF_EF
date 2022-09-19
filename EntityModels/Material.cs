using System;
using System.Collections.Generic;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class Material
    {
        public Material()
        {
            MaterialGhsList = new HashSet<MaterialJoinGHS>();
            MaterialJoinHpList = new HashSet<MaterialJoinHP>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsIntermadiate { get; set; }
        public bool? IsDanger { get; set; }
        public bool? IsProduction { get; set; }
        public bool? IsObserved { get; set; }
        public bool? IsActive { get; set; }
        public long IntermediateNrD { get; set; } = -1;
        public long ClpSignalWordId { get; set; }
        public long ClpMsdsId { get; set; }
        public long FunctionId { get; set; }
        public decimal? Price { get; set; }
        public long CurrencyId { get; set; }
        public long UnitId { get; set; }
        public double? Density { get; set; }
        public double? Solids { get; set; }
        public double? Ash450 { get; set; }
        public decimal? VOC { get; set; }
        public string Remarks { get; set; }
        public long LoginId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }

        public virtual ClpSignalWord ClpSignalWord { get; set; }
        public virtual MaterialFunction MaterialFunction { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<MaterialJoinGHS> MaterialGhsList { get; set; }
        public virtual ICollection<MaterialJoinHP> MaterialJoinHpList { get; set; }
    }
}
