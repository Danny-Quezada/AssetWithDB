using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                depreciationDbContext.Employees.Add(t);
            }
            catch
            {
                throw;
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
                depreciationDbContext.Employees.Remove(asset);
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
            return depreciationDbContext.Employees.ToList();
        }

        public int Update(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
