using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LabBook_WPF_EF.Forms.Materials.ModelView
{
    public class MaterialMV : INotifyPropertyChanged
    {

        public RelayCommand<CancelEventArgs> OnClosingCommand { get; set; }


        public MaterialMV()
        {
            OnClosingCommand = new RelayCommand<CancelEventArgs>(OnClosingCommandExecuted);
        }


        protected void OnPropertyChanged(params string[] names)
        {
            if (PropertyChanged != null)
            {
                foreach (string name in names)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public bool Modified
        {
            get
            {
                return _materialService.Modified;
            }
        }



        public void OnClosingCommandExecuted(CancelEventArgs e)
        {
            var ansver = MessageBoxResult.No;

            if (Modified)
            {
                ansver = MessageBox.Show("Dokonano zmian w rekordach. Czy zapisać zmiany?", "Zamis zmian", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            }

            if (ansver == MessageBoxResult.Yes)
            {
                SaveAll();
                WindowSetting.Save(_windowData);
            }
            else if (ansver == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                WindowSetting.Save(_windowData);
            }
        }

    }
}
