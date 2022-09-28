using LabBook_WPF_EF.EntityModels;
using LabBook_WPF_EF.Forms.Materials.ModelView;
using LabBook_WPF_EF.Navigation;
using LabBook_WPF_EF.Service;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Input;

namespace LabBook_WPF_EF.Forms.Materials
{
    /// <summary>
    /// Logika interakcji dla klasy MaterialForm.xaml
    /// </summary>
    public partial class MaterialForm : RibbonWindow
    {
        public MaterialForm(LabBookContext context, User user)
        {
            InitializeComponent();

            MaterialMV materialMV = new MaterialMV(context, user);
            DataContext = materialMV;
            NavigationMV navigationMV = Resources["navi"] as NavigationMV;

            navigationMV.ModelView = materialMV;
            materialMV.SetNavigationMV = navigationMV;
        }

        private void TxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tBox = (TextBox)sender;
                DependencyProperty prop = TextBox.TextProperty;

                BindingExpression binding = BindingOperations.GetBindingExpression(tBox, prop);
                if (binding != null) { binding.UpdateSource(); }

                TraversalRequest tRequest = new TraversalRequest(FocusNavigationDirection.Next);
                if (Keyboard.FocusedElement is UIElement keyboardFocus)
                {
                    keyboardFocus.MoveFocus(tRequest);
                }
            }
        }

        private void DgMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = DgMaterial.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            object item = DgMaterial.Items[index];
            if (!(DgMaterial.ItemContainerGenerator.ContainerFromIndex(index) is DataGridRow))
            {
                DgMaterial.ScrollIntoView(item);
            }
        }
    }
}
