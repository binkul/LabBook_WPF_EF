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
        private User _user;
        private readonly LabBookContext _contex = new LabBookContext();
        public SortableObservableCollection<Material> FullMaterials { get; private set; }
        public SortableObservableCollection<Material> Materials { get; private set; }
        public SortableObservableCollection<MaterialFunction> MaterialFunctions { get; private set; }

        public MaterialService()
        {
            PrepareData();
        }

        public int GetmaterialsCount => Materials.Count;

        internal void AttachUser(User user)
        {
            _user = user;
            _ = _contex.Users.Attach(_user);
        }

        public SortableObservableCollection<Material> GetMaterials()
        {
            List<Material> tmpMaterial = _contex.Materials
                .Where(m => (bool)m.IsIntermadiate == false)
                .OrderBy(m => m.Name)
                .Include(m => m.ClpSignalWord)
                .Include(m => m.Currency)
                .Include(m => m.Unit)
                .Include(m => m.MaterialFunction)
                .Include(m => m.MaterialJoinGhsList)
                    .ThenInclude(m => m.ClpGHS)
                .Include(m => m.MaterialJoinHpList)
                    .ThenInclude(m => m.ClpPhraseHP)
                .ToList();

            return new SortableObservableCollection<Material>(tmpMaterial);
        }

        public SortableObservableCollection<MaterialFunction> GetMaterialFunctions()
        {
            List<MaterialFunction> result = _contex.MaterialFunctions
                .OrderBy(m => m.Name)
                .ToList();

            return new SortableObservableCollection<MaterialFunction>(result);
        }

        public void PrepareData()
        {
            MaterialFunctions = GetMaterialFunctions();
            FullMaterials = GetMaterials();
            Materials = FullMaterials;
        }
    }
}
