using System.Collections.Generic;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class ClpSignalWord
    {
        public ClpSignalWord()
        {
            MaterialList = new HashSet<Material>();
            ClpPhraseHpList = new HashSet<ClpPhraseHP>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Material> MaterialList { get; set; }
        public virtual ICollection<ClpPhraseHP> ClpPhraseHpList { get; set; }

    }
}
