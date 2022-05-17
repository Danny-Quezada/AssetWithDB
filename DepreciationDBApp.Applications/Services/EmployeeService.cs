using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Applications.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private IEmployeeRepository employeeRepository;

        EmployeeService(IEmployeeRepository employeeRepositoryP)
        {
            this.employeeRepository = employeeRepositoryP;
        }
        public void Create(Employee t)
        {
            employeeRepository.Create(t);
        }

        public bool Delete(Employee t)
        {
          return  employeeRepository.Delete(t);
         
        }

        public Employee FindByDni(string dni)
        {
            return employeeRepository.FindByDni(dni);
        }

        public Employee FindByEmail(string email)
        {
            return employeeRepository.FindByEmail(email);
        }

        public IEnumerable<Employee> FindByLastname(string lastnames)
        {
            return employeeRepository.FindByLastname(lastnames);
        }

        public List<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public bool SetAssetsToEmployee(Employee employee, List<Asset> assets)
        {
            return employeeRepository.SetAssetsToEmployee(employee, assets);
        }

        public bool SetAssetToEmployee(Employee employee, Asset asset)
        {
            return employeeRepository.SetAssetToEmployee(employee, asset);
        }

        public int Update(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
