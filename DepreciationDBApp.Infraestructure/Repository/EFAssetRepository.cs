using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infraestructure.Repository
{
    public class EFAssetRepository : IAssetRepository
    {
        public IDepreciationDBContext depreciationDBContext;
        public EFAssetRepository(IDepreciationDBContext depreciationDBContext)
        {
            this.depreciationDBContext = depreciationDBContext;
        }
        public void Create(Asset t)
        {
            depreciationDBContext.Assets.Add(t);
            depreciationDBContext.SaveChanges();
        }

        public bool Delete(Asset t)
        {
            throw new NotImplementedException();
        }

        public Asset FindByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Asset FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Asset> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Asset> GetAll()
        {
            return depreciationDBContext.Assets.ToList();
        }

        public int Update(Asset t)
        {
            throw new NotImplementedException();
        }
    }
}
