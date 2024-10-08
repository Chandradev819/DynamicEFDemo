using DynamicEFDemo.Helper;
using DynamicEFDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace DynamicEFDemo.Service
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly DynamicDbContextFactory _contextFactory;

        public EmployeeService(DynamicDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Employees.ToListAsync();
        }
    }
}
