using System;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class MaterialJoinHP
    {
        public long Id { get; set; }

        public long MaterialId { get; set; }
        public Material Material { get; set; }
        public DateTime DateCreated { get; set; }

        public long HpId { get; set; }
        public ClpPhraseHP ClpPhraseHP { get; set; }

    }
}
