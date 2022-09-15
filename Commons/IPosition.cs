namespace LabBook_WPF_EF.Commons
{
    internal interface IPosition
    {
        bool SaveWindowParameters(WindowParameter parameter, string file);
        WindowParameter LoadWindowParamaters(string file);
    }
}
