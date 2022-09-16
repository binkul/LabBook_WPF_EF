using System.Collections.Generic;

namespace LabBook_WPF_EF.Commons
{
    public class WindowParameter
    {
        public double Top { get; set; } = 100;
        public double Left { get; set; } = 100;
        public double Width { get; set; } = 800;
        public double Height { get; set; } = 400;
        public IDictionary<string, double> GridColumnWidth { get; } = new Dictionary<string, double>();

        public WindowParameter()
        { }

        public WindowParameter(double top, double left, double width, double height)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        public void AddColumnWidth(string name, double width)
        {
            GridColumnWidth.Add(name, width);
        }
    }
}
