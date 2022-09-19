using System;
using System.Collections.Generic;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class ClpPhraseHP
    {
        public ClpPhraseHP()
        {
            MaterialJoinHpList = new HashSet<MaterialJoinHP>();
        }

        public long Id { get; set; }
        public string DangerClass { get; set; }
        public string Phrase { get; set; }
        public string Description { get; set; }
        public int PhraseOrder { get; set; }
        public bool IsPhraseH { get; set; }
        public long GhsId { get; set; }
        public long ClpSignalWordId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ClpGHS ClpGHS { get; set; }
        public virtual ClpSignalWord ClpSignalWord { get; set; }
        public virtual ICollection<MaterialJoinHP> MaterialJoinHpList { get; set; }
    }
}
