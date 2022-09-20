﻿using LabBook_WPF_EF.EntityModels;
using LabBook_WPF_EF.Forms.Materials.ModelView;
using LabBook_WPF_EF.Navigation;
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

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MaterialMV materialMV = (MaterialMV)DataContext;
            materialMV.PrepareForm();
        }
    }
}
