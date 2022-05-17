﻿using DepreciationDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Domain.Interfaces
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Employee FindByDni(string dni);
        Employee FindByEmail(string email);
        IEnumerable<Employee> FindByLastname(string lastnames);
        bool SetAssetToEmployee(Employee employee, Asset asset);
        bool SetAssetsToEmployee(Employee employee, List<Asset> assets);

        
    }
}
