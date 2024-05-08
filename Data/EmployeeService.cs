using EmployeeWebServer.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;


namespace EmployeeWebServer.Data
{
    public class EmployeeService
    {
        List<Employee> EmpObj;
        List<Employee> _filteredEmployees = new();
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeService(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        //Get All Employee
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employeeDbContext.Employees.ToListAsync();
        }

        //Add New Employee Record
        public async Task<bool> AddNewEmployee(Employee employee)
        {
            await _employeeDbContext.Employees.AddAsync(employee);
            await _employeeDbContext.SaveChangesAsync();
            return true;
        }

        //Get Employee Record By Id
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = await _employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return employee;
        }

        //Update Employee Data
        public async Task<bool> UpdateEmployeeDetails(Employee employee)
        {
            _employeeDbContext.Employees.Update(employee);
            await _employeeDbContext.SaveChangesAsync();
            return true;
        }

        //Delete Employee Data
        public async Task<bool> DeleteEmployeeData(Employee employee)
        {
            _employeeDbContext.Remove(employee);
            await _employeeDbContext.SaveChangesAsync();
            return true;
        }

        
    }
    
}
