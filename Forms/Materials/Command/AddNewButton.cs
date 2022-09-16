using LabBook_WPF_EF.Forms.Materials.ModelView;
using System;
using System.Windows.Input;

namespace LabBook_WPF_EF.Forms.Materials.Command
{
    internal class AddNewButton : ICommand
    {
        private readonly MaterialMV _modelView;

        public AddNewButton(MaterialMV modelView)
        {
            if (modelView == null) throw new ArgumentNullException("Model widoku jest null");
            _modelView = modelView;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _modelView.AddNew();
        }

    }
}
