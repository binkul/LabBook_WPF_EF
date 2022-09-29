using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class Material : INotifyPropertyChanged
    {
        private string _name;
        private long _functionId;
        private long _currencyId;
        private long _unitId;
        private decimal? _price;
        private bool? _isActive;
        private bool? _isProduction;
        private bool? _isDanger;
        private bool? _isObserved;
        private decimal? _voc;
        private DateTime _dateUpdated;
        
        public Material()
        {
            MaterialJoinGhsList = new HashSet<MaterialJoinGHS>();
            MaterialJoinHpList = new HashSet<MaterialJoinHP>();
        }

        public long Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Modified = true;
                DateUpdate = DateTime.Today;
                OnPropertyChanged(nameof(Name));
            }

        }
        public bool? IsIntermadiate { get; set; }
        public bool? IsDanger
        {
            get => _isDanger;
            set
            {
                _isDanger = value;
                Modified = true;
                OnPropertyChanged(nameof(IsDanger));
            }
        }
        public bool? IsProduction
        {
            get => _isProduction;
            set
            {
                _isProduction = value;
                Modified = true;
                OnPropertyChanged(nameof(IsProduction));
            }
        }
        public bool? IsObserved
        {
            get => _isObserved;
            set
            {
                _isObserved = value;
                Modified = true;
                OnPropertyChanged(nameof(IsObserved));
            }

        }
        public bool? IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                Modified = true;
                OnPropertyChanged(nameof(IsActive));
            }
        }
        public long IntermediateNrD { get; set; } = -1;
        public long ClpSignalWordId { get; set; }
        public long ClpMsdsId { get; set; }
        public long FunctionId 
        { 
            get => _functionId;
            set
            {
                _functionId = value;
                Modified = true;
                OnPropertyChanged(nameof(FunctionId));
            }
        }
        public decimal? Price
        {
            get => _price;
            set
            {
                _price = value;
                Modified = true;
                DateUpdate = DateTime.Today;
                OnPropertyChanged(nameof(Price));
            }
        }
        public long CurrencyId
        {
            get => _currencyId;
            set
            {
                _currencyId = value;
                Modified = true;
                DateUpdate = DateTime.Today;
                OnPropertyChanged(nameof(CurrencyId));
            }
        }
        public long UnitId
        {
            get => _unitId;
            set
            {
                _unitId = value;
                Modified = true;
                DateUpdate = DateTime.Today;
                OnPropertyChanged(nameof(UnitId));
            }
        }
        public double? Density { get; set; }
        public double? Solids { get; set; }
        public double? Ash450 { get; set; }
        public decimal? VOC
        {
            get => _voc;
            set
            {
                _voc = value;
                Modified = true;
                OnPropertyChanged(nameof(VOC));
            }
        }
        public string Remarks { get; set; }
        public long LoginId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate
        {
            get => _dateUpdated;
            set
            {
                _dateUpdated = value;
                OnPropertyChanged(nameof(DateUpdate));
            }
        }

        public virtual ClpSignalWord ClpSignalWord { get; set; }
        public virtual MaterialFunction MaterialFunction { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<MaterialJoinGHS> MaterialJoinGhsList { get; set; }
        public virtual ICollection<MaterialJoinHP> MaterialJoinHpList { get; set; }

        public bool Modified { get; set; } = false;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(params string[] names)
        {
            if (PropertyChanged != null)
            {
                foreach (string name in names)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
