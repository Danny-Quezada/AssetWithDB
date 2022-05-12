using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFAssetRepository : IAssetRepository
    {
        public IDepreciationDbContext depreciationDbContext;

        public EFAssetRepository(IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDbContext = depreciationDbContext;
        }
        public void Create(Asset t)
        {
            try
            {
                depreciationDbContext.Assets.Add(t);
                depreciationDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(Asset t)
        {
            try
            {

                if (t == null)
                {
                    throw new ArgumentException("Object null");
                }
                Asset asset = FindById(t.Id);
                if (asset == null)
                {
                    throw new Exception($"Object with Id {t.Id} not exist");
                }
                depreciationDbContext.Assets.Remove(asset);
                int result = depreciationDbContext.SaveChanges();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    
        public Asset FindByCode(string code)
        {
            try
            {
                List<Asset> assets = GetAll();
                return assets.First(x => x.Code.Equals(code));
            }
            catch
            {
                throw;
            }
        }

        public Asset FindById(int id)
        {
            try
            {

                List<Asset> assets = GetAll();
                return assets.Find(x => x.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public List<Asset> FindByName(string name)
        {
            try
            {
                List<Asset> assets = GetAll();
                return (List<Asset>)assets.Where<Asset>(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Asset> GetAll()
        {
            try
            {
                return depreciationDbContext.Assets.ToList();
            }
            catch
            {
                throw;
            }
        }

        public int Update(Asset t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("Object null");
                }
                Asset asset = FindById(t.Id);
                if (asset == null)
                {
                    throw new Exception($"Object with Id {t.Id} not exist");
                }

                asset.Name = t.Name;
                asset.Description = t.Description;
                asset.Code = t.Code;
                asset.Id = t.Id;
                asset.IsActive = t.IsActive;
                asset.AmountResidual = t.AmountResidual;
                asset.Amount = t.Amount;
                asset.Status = t.Status;
                asset.Terms = t.Terms;

                depreciationDbContext.Assets.Update(asset);
                return depreciationDbContext.SaveChanges();
                
            }
            catch
            {
                throw;
            }
        }
    }
}
