using System.Windows;

namespace LabBook_WPF_EF.Commons
{
    public class DataContextProxy : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new DataContextProxy();
        }

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(DataContextProxy), new UIPropertyMetadata(null));
    }
}
