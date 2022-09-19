using System.Collections.Generic;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class ClpGHS
    {
        public ClpGHS()
        {
            MaterialGhslist = new HashSet<MaterialJoinGHS>();
            ClpPhraseHpList = new HashSet<ClpPhraseHP>();
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public int GHS { get; set; }
        public string FileName { get; set; }

        public virtual ICollection<MaterialJoinGHS> MaterialGhslist { get; set; }
        public virtual ICollection<ClpPhraseHP> ClpPhraseHpList { get; set; }

    }
}
