using LabBook_WPF_EF.Commons;
using LabBook_WPF_EF.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBook_WPF_EF.Service
{
    internal class MaterialService
    {
        private readonly User _user;
        private readonly LabBookContext _contex;
        public SortableObservableCollection<Material> FullMaterials { get; private set; }
        public SortableObservableCollection<Material> Materials { get; private set; }

        public MaterialService(User user, LabBookContext labBookContext)
        {
            _user = user;
            _contex = labBookContext;
            //FullMaterials = GetMaterials();
            //Materials = FullMaterials;
        }

        public SortableObservableCollection<Material> GetMaterials()
        {
            List<Material> tmpMaterial = _contex.Materials
                .Include(m => m.ClpSignalWord)
                .Include(m => m.Currency)
                .Include(m => m.Unit)
                .Include(m => m.MaterialFunction)
                .Include(m => m.MaterialJoinGhsList)
                    .ThenInclude(m => m.ClpGHS)
                .Include(m => m.MaterialJoinHpList)
                    .ThenInclude( m => m.ClpPhraseHP)
                .OrderBy(m => m.Name)
                .ToList();

            return new SortableObservableCollection<Material>(tmpMaterial);
        }

        public void PrepareData()
        {
            FullMaterials = GetMaterials();
            Materials = FullMaterials;
        }
    }
}
