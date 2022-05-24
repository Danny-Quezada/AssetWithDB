using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Enums;
using DepreciationDBApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFEmployeRepository : IEmployeeRepository
    {
        public IDepreciationDbContext depreciationDbContext;

        public EFEmployeRepository(IDepreciationDbContext depreciationDb)
        {
            this.depreciationDbContext = depreciationDb;
        }
        public void Create(Employee t)
        {
            try
            {
                ValidateEmployee(t);
                depreciationDbContext.Employee.Add(t);
                depreciationDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        private void ValidateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("El objeto employee no puede ser nulo");

            }
            if (string.IsNullOrEmpty(employee.Email))
            {
                throw new ArgumentException("El email no puede ser nulo o estar vacio");

            }
        }

        public bool Delete(Employee t)
        {
            try
            {

                if (t == null)
                {
                    throw new ArgumentException("Object null");
                }
                Employee asset = FindByDni(t.Dni);
                if (asset == null)
                {
                    throw new Exception($"Object with Id {t.Id} not exist");
                }
                depreciationDbContext.Employee.Remove(asset);
                int result = depreciationDbContext.SaveChanges();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Employee FindByDni(string dni)
        {
            try
            {
                List<Employee> employees = GetAll();
                return employees.First(x => x.Dni.Equals(dni, StringComparison.CurrentCultureIgnoreCase));
            }
            catch
            {
                throw;
            }
        }

        public Employee FindByEmail(string email)
        {
            try
            {
                List<Employee> employees = GetAll();
                return employees.First(x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Employee> FindByLastname(string lastnames)
        {
            try
            {
                List<Employee> employees = GetAll();

                return (List<Employee>)employees.Where(x => x.Lastname.Equals(lastnames, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Employee> GetAll()
        {
            return depreciationDbContext.Employee.ToList();
        }

        public bool SetAssetsToEmployee(Employee employee, List<Asset> assets)
        {
            if (employee == null && assets == null)
            {
                throw new ArgumentException("Los objetos no pueden ser nulos");
            }
            Employee Valideemployee = FindByDni(employee.Dni);

            if (Valideemployee == null)
            {
                throw new ArgumentException($"El objeto con {employee.Dni} no se encuentra en la base de datos.");
            }
            foreach (Asset asset in assets)
            {
                if (asset == null)
                {
                    throw new ArgumentException("El asset no puede ser nulo");
                }
                if (asset.Status == StatusAsset.Asignado.ToString())
                {
                    throw new ArgumentException($"El asset {asset.Name} ya esta asignado");
                }
                if (asset.IsActive == false)
                {
                    throw new ArgumentException($"El asset {asset.Name} no se encuentra activo");
                }
            }

            foreach (Asset asset in assets)
            {
                AssetEmployee assetEmployee = new AssetEmployee
                {
                    Asset = asset,
                    Employee = employee,
                    AssetId = asset.Id,
                    IsActive = asset.IsActive,
                    Date = DateTime.Now,
                    EmployeeId = employee.Id,

                };
                depreciationDbContext.AssetEmployees.Add(assetEmployee);
            }
            return true;
        }

        public bool SetAssetToEmployee(Employee employee, Asset asset)
        {
                        if (employee == null && asset == null)
            {
                throw new ArgumentException("Los objetos no pueden ser nulos");
            }
            Employee valideEmployee = FindByDni(employee.Dni);
            if (valideEmployee == null)
            {
                throw new ArgumentException($"El empleado {employee.Names} no se encuentra en la base de datos");
            }
            if (asset.Status == StatusAsset.Asignado.ToString())
            {
                throw new ArgumentException($"El asset {asset.Name} se encuentra ya asignado");
            }
            if (asset.IsActive == false)
            {
                throw new ArgumentException($"El asset {asset.Name} no se encuentra activo");
            }
            AssetEmployee assetEmployee = new AssetEmployee
            {
                Asset = asset,
                AssetId = asset.Id,
                Date = DateTime.Now,
                IsActive = true,
                Employee = employee,
                EmployeeId = employee.Id,
            };
            depreciationDbContext.AssetEmployees.Add(assetEmployee);
            depreciationDbContext.SaveChanges();
            return true;
        }

        public int Update(Employee t)
        {
            throw new NotImplementedException();
        }
        public IDbContextTransaction GetTransaction()
        {
            return ((DepreciationDBApp.Domain.DepreciationDBApp.Domain.DepreciationDBContext)depreciationDbContext).Database.BeginTransaction();
        }
    }
}
