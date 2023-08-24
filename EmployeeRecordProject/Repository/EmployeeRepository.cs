using EmployeeRecordProject.DataConnection;
using EmployeeRecordProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeRecordProject.Repository
{
    public class EmployeeRepository
    {
        private EmployeeDBContext _context;

        public EmployeeRepository()
        {
            _context = new EmployeeDBContext();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}