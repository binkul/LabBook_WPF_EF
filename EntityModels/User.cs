using System;
using System.Collections.Generic;

namespace LabBook_WPF_EF.EntityModels
{
    public partial class User
    {
        public User()
        {
            MaterialList = new HashSet<Material>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
        public string Identifier { get; set; }
        public bool? Active { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Material> MaterialList { get; set; }

    }
}
