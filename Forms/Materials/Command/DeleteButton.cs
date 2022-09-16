using LabBook_WPF_EF.Forms.Materials.ModelView;
using System;
using System.Windows.Input;

namespace LabBook_WPF_EF.Forms.Materials.Command
{
    internal class DeleteButton : ICommand
    {
        private readonly MaterialMV _modelView;

        public DeleteButton(MaterialMV modelView)
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
            return _modelView.GetRowCount > 0;
        }

        public void Execute(object parameter)
        {
            _modelView.Delete();
        }
    }
}
