using AtlasApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlasApp.Domain.IRepository
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);

        Task Update(Employee employee);

        Task Delete(string id);

        Task<Employee> GetEmployee(string id);

        Task<IEnumerable<Employee>> GetEmployees();
    }
}