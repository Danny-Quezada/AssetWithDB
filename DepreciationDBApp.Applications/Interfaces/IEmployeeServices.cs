using DepreciationDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Applications.Interfaces
{
   public interface IEmployeeServices: IService<Employee>
    {
        Employee FindByDni(string dni);
        Employee FindByEmail(string email);
        IEnumerable<Employee> FindByLastname(string lastnames);
        bool SetAssetToEmployee(Employee employee, Asset asset);
        bool SetAssetsToEmployee(Employee employee, List<Asset> assets);
    }
}
