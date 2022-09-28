using System.Collections.Generic;

namespace LabBook_WPF_EF.Commons
{
    public class WindowParameter
    {
        private static double _standardWidth = 100;

        public double Top { get; set; } = _standardWidth;
        public double Left { get; set; } = _standardWidth;
        public double Width { get; set; } = 8 * _standardWidth;
        public double Height { get; set; } = 4 * _standardWidth;
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
            if (!GridColumnWidth.ContainsKey(name))
                GridColumnWidth.Add(name, width);
            else
                GridColumnWidth[name] = width;
        }

        public double GetGridColummnWidth(string name)
        {
            return GridColumnWidth.ContainsKey(name) ? GridColumnWidth[name] : _standardWidth;
        }

        public bool IsAnyGridWidth()
        {
            return GridColumnWidth.Count > 0;
        }
    }
}
