using AtlasApp.Domain.Entities;
using AtlasApp.Domain.IRepository;

namespace AtlasApp.Domain.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AtlasAppContext dbContext) : base(dbContext)
        {
        }
    }
}