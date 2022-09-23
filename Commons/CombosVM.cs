using LabBook_WPF_EF.EntityModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LabBook_WPF_EF.Commons
{
    internal class CombosVM : INotifyPropertyChanged
    {
        private readonly LabBookContext _context;
        private readonly List<MaterialFunction> _materialFunctions;
        private readonly List<Currency> _currencies;

        public CombosVM()
        {
            _context = new LabBookContext();
            _materialFunctions = GetMaterialFunction();
            _currencies = GetCurrencies();
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

        public List<MaterialFunction> MaterialFunctions => _materialFunctions;
        public List<Currency> Currencies => _currencies;

        private List<MaterialFunction> GetMaterialFunction()
        {
            return _context.MaterialFunctions
                .OrderBy(m => m.Name)
                .ToList();
        }

        private List<Currency> GetCurrencies()
        {
            return _context.Currencies
                .OrderBy(m => m.Name)
                .ToList();
        }
    }
}
