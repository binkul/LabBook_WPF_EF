using GalaSoft.MvvmLight.Command;
using LabBook_WPF_EF.Commons;
using LabBook_WPF_EF.EntityModels;
using LabBook_WPF_EF.Forms.Materials.Command;
using LabBook_WPF_EF.Navigation;
using LabBook_WPF_EF.Service;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LabBook_WPF_EF.Forms.Materials.ModelView
{
    public class MaterialMV : INotifyPropertyChanged, INavigation
    {
        private readonly string _formPath = @"\Data\Forms\MaterialForm.xml";

        private ICommand _saveButton;
        private ICommand _deleteButton;
        private ICommand _addNewButton;
        private ICommand _clpButton;

        private double _colNameWidth = 100;
        private double _colFunctionWidth = 100;
        private double _colPriceWidth = 100;

        private NavigationMV _navigationMV;
        private int _selectedIndex = 0;
        private readonly WindowFunction _windowFunction;
        private readonly MaterialService _service;
        private readonly WindowParameter _windowParameter;
        public RelayCommand<CancelEventArgs> OnClosingCommand { get; set; }
        public RelayCommand<SelectionChangedEventArgs> OnComboSelectionIndexChanged { get; set; }


        public MaterialMV(LabBookContext context, User user)
        {
            _windowFunction = new WindowFunction();
            _windowParameter = _windowFunction.LoadWindowParamaters(_formPath); // new WindowParameter();
            _service = new MaterialService(user, context);
            OnClosingCommand = new RelayCommand<CancelEventArgs>(OnClosingCommandExecuted);
            OnComboSelectionIndexChanged = new RelayCommand<SelectionChangedEventArgs>(OnComboSelectionIndexChangedExecuted);

            OnPropertyChanged(nameof(FormLeft), nameof(FormTop), nameof(FormWidth), nameof(FormHeight));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(params string[] names)
        {
            if (PropertyChanged != null)
            {
                foreach (string name in names)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        internal NavigationMV SetNavigationMV
        {
            set => _navigationMV = value;
        }

        public double FormLeft
        {
            get => _windowParameter.Left;

            set
            {
                _windowParameter.Left = value;
                OnPropertyChanged(nameof(FormLeft));
            }
        }

        public double FormTop
        {
            get => _windowParameter.Top;
            set
            {
                _windowParameter.Top = value;
                OnPropertyChanged(nameof(FormTop));
            }
        }

        public double FormWidth
        {
            get => _windowParameter.Width;
            set
            {
                _windowParameter.Width = value;
                OnPropertyChanged(nameof(FormWidth));
            }
        }

        public double FormHeight
        {
            get => _windowParameter.Height;
            set
            {
                _windowParameter.Height = value;
                OnPropertyChanged(nameof(FormHeight));
            }
        }

        public double ColNameWidth
        {
            get => _colNameWidth;
            set
            {
                _colNameWidth = value;
                OnPropertyChanged(nameof(ColNameWidth));
            }    
        }

        public double ColFunctionWidth
        {
            get => _colFunctionWidth;
            set
            {
                _colFunctionWidth = value;
                OnPropertyChanged(nameof(ColFunctionWidth));
            }
        }

        public double ColPriceWidth
        {
            get => _colPriceWidth;
            set
            {
                _colPriceWidth = value;
                OnPropertyChanged(nameof(ColPriceWidth));
            }
        }

        public bool Modified => false; // _materialService.Modified;

        public bool IsDanger => true;

        public SortableObservableCollection<Material> Materials => _service.Materials;

        public SortableObservableCollection<MaterialFunction> MaterialFunctions => _service.MaterialFunctions;

        public void OnClosingCommandExecuted(CancelEventArgs e)
        {
            var answer = MessageBoxResult.No;

            if (Modified)
            {
                answer = MessageBox.Show("Dokonano zmian w rekordach. Czy zapisać zmiany?", "Zampis zmian", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            }

            if (answer == MessageBoxResult.Yes)
            {
                Save();
                _windowParameter.AddColumnWidth("Name", _colNameWidth);
                _windowParameter.AddColumnWidth("Function", _colFunctionWidth);
                _windowParameter.AddColumnWidth("Price", _colPriceWidth);
                _ = _windowFunction.SaveWindowParameters(_windowParameter, _formPath);
            }
            else if (answer == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                _windowParameter.AddColumnWidth("Name", _colNameWidth);
                _windowParameter.AddColumnWidth("Function", _colFunctionWidth);
                _windowParameter.AddColumnWidth("Price", _colPriceWidth);
                _ = _windowFunction.SaveWindowParameters(_windowParameter, _formPath);
            }
        }

        public void OnComboSelectionIndexChangedExecuted(SelectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Materials));
        }

        #region Navigation

        public int GetRowCount => 0; // _service.GetQualityCount; //ok

        public int DgRowIndex //ok
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;

                //if (value >= 0 && _service.GetQualityCount != 0 && value < _service.GetQualityCount)
                //{
                //    QualityControl quality = _service.Quality[_selectedIndex];
                //    _service.RefreshQualityData(quality);
                //    IsTextBoxActive = true;
                //}
                //else
                //{
                //    _service.RefreshQualityData(null);
                //    IsTextBoxActive = false;
                //}
                OnPropertyChanged(nameof(DgRowIndex));
                //    nameof(IsAnyQuality),
                //    nameof(IsTextBoxActive),
                //    nameof(GetActiveFields),
                //    nameof(QualityData));

                Refresh();
            }
        }

        public void Refresh()
        {
            if (_navigationMV != null)
                _navigationMV.Refresh();
        }

        #endregion

        #region Buttons and Commands

        public ICommand SaveButton
        {
            get
            {
                if (_saveButton == null) _saveButton = new SaveButton(this);
                return _saveButton;
            }
        }

        public ICommand DeleteButton
        {
            get
            {
                if (_deleteButton == null) _deleteButton = new DeleteButton(this);
                return _deleteButton;
            }
        }

        public ICommand AddNewButton
        {
            get
            {
                if (_addNewButton == null) _addNewButton = new AddNewButton(this);
                return _addNewButton;
            }
        }

        public ICommand ClpButton
        {
            get
            {
                if (_clpButton == null) _clpButton = new ClpButton(this);
                return _clpButton;
            }
        }

        internal void Save()
        {

        }

        internal void Delete()
        {

        }

        internal void AddNew()
        {

        }

        internal void OpenClp()
        {

        }

        #endregion
    }
}
