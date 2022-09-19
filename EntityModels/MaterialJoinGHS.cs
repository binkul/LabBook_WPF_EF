namespace LabBook_WPF_EF.EntityModels
{
    public partial class MaterialJoinGHS
    {
        public long MaterialId { get; set; }
        public Material Material { get; set; }


        public long GhsId { get; set; }
        public ClpGHS ClpGHS { get; set; }
    }
}
