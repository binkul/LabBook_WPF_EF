using System;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class MaterialJoinGHS
    {
        public long Id { get; set; }

        public long MaterialId { get; set; }
        public Material Material { get; set; }
        public DateTime DateCreated { get; set; }

        public long GhsId { get; set; }
        public ClpGHS ClpGHS { get; set; }
    }
}
