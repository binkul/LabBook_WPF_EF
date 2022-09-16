namespace LabBook_WPF_EF.Navigation
{
    internal interface INavigation
    {
        int DgRowIndex { get; set; }

        int GetRowCount { get; }

        void Refresh();
    }
}
